using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _rand = new Random();

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    ) { }

    protected override void RunActivity(DateTime endTime)
    {
        string prompt = _prompts[_rand.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("You will have a few seconds to think, then start listing items (press Enter after each).");
        Console.Write("Get ready: ");
        ShowCountdown(5);
        Console.WriteLine();

        List<string> entries = new List<string>();

        // Collect items from the user until time is up.
        // Note: Console.ReadLine is blocking; user may linger — this is acceptable per simplifications.
        while (DateTime.Now < endTime)
        {
            TimeSpan remaining = endTime - DateTime.Now;
            Console.Write($"({(int)remaining.TotalSeconds}s left) > ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                // allow empty input to be ignored
                continue;
            }
            entries.Add(input.Trim());
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {entries.Count} item(s).");
        if (entries.Count > 0)
        {
            Console.WriteLine("Your items:");
            foreach (var item in entries)
            {
                Console.WriteLine($" - {item}");
            }
        }
    }
}
