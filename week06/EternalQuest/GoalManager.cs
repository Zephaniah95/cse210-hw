using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    // Manages the list of goals and the user's score, plus save/load
    public class GoalManager
    {
        public List<Goal> Goals { get; private set; } = new List<Goal>();
        public int Score { get; private set; } = 0;

        // Creatively add leveling and badges: level every 1000 points, badges at thresholds
        public int Level => 1 + (Score / 1000);
        public List<string> Badges
        {
            get
            {
                var list = new List<string>();
                if (Score >= 100) list.Add("Bronze Star");
                if (Score >= 500) list.Add("Silver Star");
                if (Score >= 1000) list.Add("Gold Star");
                if (Score >= 5000) list.Add("Legend");
                return list;
            }
        }

        public void AddGoal(Goal g) => Goals.Add(g);

        public void RecordEvent(int index)
        {
            if (index < 0 || index >= Goals.Count)
            {
                Console.WriteLine("Invalid goal index.");
                return;
            }

            Goal g = Goals[index];
            int awarded = g.RecordEvent();
            Score += awarded;
            Console.WriteLine($"You earned {awarded} point(s). Total score: {Score}");
        }

        public void ListGoals()
        {
            if (Goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            for (int i = 0; i < Goals.Count; i++)
            {
                Goal g = Goals[i];
                Console.WriteLine($"{i+1}. {g.GetStatus()}  -- {g.Name}");
            }
        }

        // Save to a simple text format
        public void Save(string filepath)
        {
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                // First line holds score
                sw.WriteLine($"SCORE|{Score}");
                // Then each goal serialized
                foreach (var g in Goals)
                {
                    sw.WriteLine(g.Serialize());
                }
            }
            Console.WriteLine($"Saved to {filepath}");
        }

        // Load reading the same format. Existing state replaced.
        public void Load(string filepath)
        {
            if (!File.Exists(filepath))
            {
                Console.WriteLine("Save file not found.");
                return;
            }

            var lines = File.ReadAllLines(filepath);
            Goals.Clear();
            Score = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split('|');
                if (parts.Length == 0) continue;

                if (parts[0] == "SCORE")
                {
                    if (parts.Length >= 2) Score = int.Parse(parts[1]);
                }
                else if (parts[0] == "Simple")
                {
                    // Simple|name|points|completed
                    var name = parts[1];
                    var points = int.Parse(parts[2]);
                    var goal = new SimpleGoal(name, points);
                    goal.DeserializeState(parts);
                    Goals.Add(goal);
                }
                else if (parts[0] == "Eternal")
                {
                    // Eternal|name|points|timesRecorded
                    var name = parts[1];
                    var points = int.Parse(parts[2]);
                    var goal = new EternalGoal(name, points);
                    goal.DeserializeState(parts);
                    Goals.Add(goal);
                }
                else if (parts[0] == "Checklist")
                {
                    // Checklist|name|points|requiredCount|bonus|timesCompleted|completed
                    var name = parts[1];
                    var points = int.Parse(parts[2]);
                    var required = int.Parse(parts[3]);
                    var bonus = int.Parse(parts[4]);
                    var goal = new ChecklistGoal(name, points, required, bonus);
                    goal.DeserializeState(parts);
                    Goals.Add(goal);
                }
            }

            Console.WriteLine($"Loaded {Goals.Count} goals. Score: {Score}");
        }
    }
}
