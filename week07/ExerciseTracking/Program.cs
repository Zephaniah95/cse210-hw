using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        // Create one of each activity
        activities.Add(new Running("03 Nov 2024", 30, 3.0));
        activities.Add(new Cycling("04 Nov 2024", 45, 15.0));
        activities.Add(new Swimming("05 Nov 2024", 40, 30));

        // Display summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
