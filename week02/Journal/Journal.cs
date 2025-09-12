using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace JournalApp
{
    // Models the responsibilities of a Journal
    public class Journal
    {
        // Member variable as requested style: _underscoreCamelCase
        private readonly List<Entry> _entries;

        public IReadOnlyList<Entry> Entries => _entries.AsReadOnly();

        public Journal()
        {
            _entries = new List<Entry>();
        }

        // Adds an entry
        public void AddEntry(Entry e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            _entries.Add(e);
        }

        // Displays all entries to console
        public void DisplayAll()
        {
            if (!_entries.Any())
            {
                Console.WriteLine("Journal is empty.");
                return;
            }

            Console.WriteLine($"--- Journal ({_entries.Count} entries) ---");
            int i = 1;
            foreach (var entry in _entries)
            {
                Console.WriteLine($"Entry #{i++}");
                Console.WriteLine(entry.ToString());
            }

            // Small report: top moods and tag counts (extra credit)
            DisplayStatsSummary();
        }

        // Summary stats (extra credit)
        public void DisplayStatsSummary()
        {
            if (!_entries.Any()) return;

            var moodCounts = _entries
                .Where(e => !string.IsNullOrWhiteSpace(e.Mood))
                .GroupBy(e => e.Mood.Trim(), StringComparer.OrdinalIgnoreCase)
                .Select(g => new { Mood = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5);

            var tagCounts = _entries
                .Where(e => !string.IsNullOrWhiteSpace(e.Tag))
                .GroupBy(e => e.Tag.Trim(), StringComparer.OrdinalIgnoreCase)
                .Select(g => new { Tag = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(5);

            Console.WriteLine("--- Quick Summary ---");
            Console.WriteLine($"Total entries: {_entries.Count}");
            if (moodCounts.Any())
            {
                Console.WriteLine("Top moods:");
                foreach (var m in moodCounts) Console.WriteLine($"  {m.Mood}: {m.Count}");
            }
            if (tagCounts.Any())
            {
                Console.WriteLine("Top tags:");
                foreach (var t in tagCounts) Console.WriteLine($"  {t.Tag}: {t.Count}");
            }
        }

        // Saves the journal to a file. Supports "json" or "csv" (custom separator).
        public void SaveToFile(string filename, string format = "json")
        {
            if (string.IsNullOrWhiteSpace(filename)) throw new ArgumentException("filename required");

            format = format?.ToLowerInvariant() ?? "json";

            if (format == "json")
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                var json = JsonSerializer.Serialize(_entries, options);
                File.WriteAllText(filename, json, Encoding.UTF8);
            }
            else if (format == "csv")
            {
                // custom separator to avoid CSV quoting complexity
                string sep = "~|~";
                var sb = new StringBuilder();
                // header
                sb.AppendLine($"Date{sep}Prompt{sep}Response{sep}Mood{sep}Tag");
                foreach (var e in _entries)
                {
                    sb.AppendLine(e.ToCsvLine(sep));
                }

                File.WriteAllText(filename, sb.ToString(), Encoding.UTF8);
            }
            else
            {
                throw new NotSupportedException("Format must be 'json' or 'csv'");
            }
        }

        // Loads a journal from a file. Replaces current entries.
        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename)) throw new FileNotFoundException("File not found", filename);

            var content = File.ReadAllText(filename, Encoding.UTF8).TrimStart();

            // Try JSON first (robust)
            if (content.StartsWith("[") || content.StartsWith("{"))
            {
                try
                {
                    var arr = JsonSerializer.Deserialize<List<Entry>>(content);
                    if (arr != null)
                    {
                        _entries.Clear();
                        _entries.AddRange(arr);
                        return;
                    }
                }
                catch
                {
                    // fall through to CSV parsing
                }
            }

            // Fallback: parse CSV with our custom separator
            // We expect header then lines with separator "~|~"
            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length == 0) return;

            string sep = "~|~";
            var parsed = new List<Entry>();

            // If header contains sep, skip header
            int startIndex = 0;
            if (lines[0].Contains(sep)) startIndex = 1;

            for (int i = startIndex; i < lines.Length; i++)
            {
                var parts = lines[i].Split(new[] { sep }, StringSplitOptions.None);
                // parts: Date | Prompt | Response | Mood | Tag
                string date = parts.Length > 0 ? parts[0] : "";
                string prompt = parts.Length > 1 ? parts[1] : "";
                string response = parts.Length > 2 ? parts[2] : "";
                string mood = parts.Length > 3 ? parts[3] : "";
                string tag = parts.Length > 4 ? parts[4] : "";
                parsed.Add(new Entry(prompt, response, date, mood, tag));
            }

            _entries.Clear();
            _entries.AddRange(parsed);
        }

        // Clears the journal
        public void Clear()
        {
            _entries.Clear();
        }
    }
}
