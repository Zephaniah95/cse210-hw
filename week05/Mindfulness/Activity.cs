using System;
using System.Threading;

public abstract class Activity
{
    // Encapsulated fields
    private string _name;
    private string _description;
    private int _durationSeconds; // set per activity run

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Public interface to start the activity
    public void Run()
    {
        Console.Clear();
        ShowStartingMessage();
        Console.Write("Enter duration in seconds: ");
        while (!int.TryParse(Console.ReadLine(), out _durationSeconds) || _durationSeconds <= 0)
        {
            Console.Write("Please enter a positive whole number for seconds: ");
        }

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        PauseWithDots(3);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_durationSeconds);

        // Call activity-specific implementation
        RunActivity(endTime);

        // Ending sequence
        Console.WriteLine();
        ShowEndingMessage();
        PauseWithDots(3);
    }

    // Implemented by derived classes
    protected abstract void RunActivity(DateTime endTime);

    // Shared helpers
    protected void ShowStartingMessage()
    {
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    protected void ShowEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed the {_name} for the requested time.");
    }

    // Spinner animation for 'seconds' seconds
    protected void PauseWithSpinner(int seconds)
    {
        char[] spinner = new char[] { '|', '/', '-', '\\' };
        DateTime start = DateTime.Now;
        int i = 0;
        while ((DateTime.Now - start).TotalSeconds < seconds)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
        }
    }

    // Countdown numbers on screen for n seconds
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Simple dot animation for a few seconds (used in start/end)
    protected void PauseWithDots(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    // Accessors for derived classes (if needed)
    protected int DurationSeconds => _durationSeconds;
    protected string Name => _name;
}
