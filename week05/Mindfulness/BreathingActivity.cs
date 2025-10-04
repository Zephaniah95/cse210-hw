using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
    ) { }

    protected override void RunActivity(DateTime endTime)
    {
        // We'll alternate "Breathe in..." and "Breathe out..."
        // Use a small inhale/exhale duration (configurable)
        int inhaleSeconds = 4;
        int exhaleSeconds = 6;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountdown(inhaleSeconds);
            if (DateTime.Now >= endTime) break;

            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountdown(exhaleSeconds);
        }
    }
}
