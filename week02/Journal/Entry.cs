using System;
using System.Text.Json.Serialization;

namespace JournalApp
{
    // Models a single journal entry.
    // Public properties use TitleCase.
    public class Entry
    {
        // The prompt shown to the user
        public string Prompt { get; set; }

        // The user's response
        public string Response { get; set; }

        // Date stored as a string as allowed by the spec
        public string Date { get; set; }

        // A simple optional mood (e.g., "Happy", "Sad", "Reflective")
        public string Mood { get; set; }

        // Optional short tag to categorize the entry (e.g., "work", "family")
        public string Tag { get; set; }

        // Parameterless ctor required for JSON deserialization
        public Entry() { }

        public Entry(string prompt, string response, string date, string mood = "", string tag = "")
        {
            Prompt = prompt;
            Response = response;
            Date = date;
            Mood = mood;
            Tag = tag;
        }

        // Returns a single-line CSV-safe representation using a custom separator.
        // We escape occurrences of the separator inside fields by replacing them.
        public string ToCsvLine(string separator = "~|~")
        {
            string esc(string s) => s?.Replace(separator, " ") ?? "";
            return $"{esc(Date)}{separator}{esc(Prompt)}{separator}{esc(Response)}{separator}{esc(Mood)}{separator}{esc(Tag)}";
        }

        // For display
        public override string ToString()
        {
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nMood: {Mood}\nTag: {Tag}\n";
        }
    }
}
