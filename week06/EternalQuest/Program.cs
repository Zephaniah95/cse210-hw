using System;

namespace EternalQuest
{
    class Program
    {
        // EXTRAS / Creativity (explained here as required by assignment):
        //  - Leveling system: Player gets a level for each 1000 points.
        //  - Badges: Awarded at thresholds (100, 500, 1000, 5000).
        //  - Save file format is a simple text format for portability.
        // These exceed the base requirements by adding motivation and feedback loops.

        static void Main(string[] args)
        {
            var manager = new GoalManager();

            Console.WriteLine("Welcome to Eternal Quest!");
            bool running = true;
            string savePath = "saved_goals.txt";

            while (running)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. Create a new goal");
                Console.WriteLine("2. List goals");
                Console.WriteLine("3. Record an event (complete/advance a goal)");
                Console.WriteLine("4. Show score, level, and badges");
                Console.WriteLine("5. Save goals");
                Console.WriteLine("6. Load goals");
                Console.WriteLine("7. Quit");
                Console.Write("Choose an option: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateGoal(manager);
                        break;
                    case "2":
                        manager.ListGoals();
                        break;
                    case "3":
                        RecordEvent(manager);
                        break;
                    case "4":
                        ShowScore(manager);
                        break;
                    case "5":
                        Console.Write($"Enter save file path (default: {savePath}): ");
                        var sPath = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(sPath)) savePath = sPath;
                        manager.Save(savePath);
                        break;
                    case "6":
                        Console.Write($"Enter load file path (default: {savePath}): ");
                        var lPath = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(lPath)) savePath = lPath;
                        manager.Load(savePath);
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            Console.WriteLine("Goodbye — keep progressing on your Eternal Quest!");
        }

        static void CreateGoal(GoalManager manager)
        {
            Console.WriteLine("Choose goal type: 1) Simple 2) Eternal 3) Checklist");
            var t = Console.ReadLine();

            Console.Write("Enter goal name/description: ");
            var name = Console.ReadLine();

            int points = ReadInt("Enter points awarded each time this goal is recorded: ");

            if (t == "1")
            {
                var g = new SimpleGoal(name, points);
                manager.AddGoal(g);
            }
            else if (t == "2")
            {
                var g = new EternalGoal(name, points);
                manager.AddGoal(g);
            }
            else if (t == "3")
            {
                int required = ReadInt("Enter how many times it must be completed to finish: ");
                int bonus = ReadInt("Enter bonus points awarded when completed: ");
                var g = new ChecklistGoal(name, points, required, bonus);
                manager.AddGoal(g);
            }
            else
            {
                Console.WriteLine("Invalid type.");
                return;
            }

            Console.WriteLine("Goal created.");
        }

        static void RecordEvent(GoalManager manager)
        {
            if (manager.Goals.Count == 0)
            {
                Console.WriteLine("No goals to record.");
                return;
            }

            manager.ListGoals();
            int idx = ReadInt("Enter goal number to record event for: ") - 1;
            manager.RecordEvent(idx);
        }

        static void ShowScore(GoalManager manager)
        {
            Console.WriteLine($"Score: {manager.Score}");
            Console.WriteLine($"Level: {manager.Level}");
            Console.WriteLine("Badges: " + (manager.Badges.Count == 0 ? "None" : string.Join(", ", manager.Badges)));
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (int.TryParse(s, out int val)) return val;
                Console.WriteLine("Please enter a valid integer.");
            }
        }
    }
}
