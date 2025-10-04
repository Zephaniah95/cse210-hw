using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _rand = new Random();

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience."
    ) { }

    protected override void RunActivity(DateTime endTime)
    {
        // Show a random prompt
        string prompt = _prompts[_rand.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now consider the following questions related to this experience.");
        Console.WriteLine("You will have time to reflect on each — a spinner will show while you think.");
        PauseWithDots(2);

        // Show random questions until time's up
        while (DateTime.Now < endTime)
        {
            string question = _questions[_rand.Next(_questions.Count)];
            Console.WriteLine();
            Console.WriteLine($"-> {question}");
            // Pause with spinner for a few seconds to let user reflect
            int pauseSec = 6;
            if ((endTime - DateTime.Now).TotalSeconds < pauseSec)
            {
                // Use remaining time if less than pauseSec
                int remaining = Math.Max(1, (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds));
                PauseWithSpinner(remaining);
                break;
            }
            else
            {
                PauseWithSpinner(pauseSec);
            }
        }
    }
}
