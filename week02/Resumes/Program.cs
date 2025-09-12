using System;

class Program
{
    static void Main(string[] args)
    {
         // Create first job
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "SpitalLabs";
        job1._startYear = 2018;
        job1._endYear = 2020;

        // Create second job
        Job job2 = new Job();
        job2._jobTitle = "Graphic Designer";
        job2._company = "Zeph-Tech-Hub";
        job2._startYear = 2020;
        job2._endYear = 2024;

        // Create resume
        Resume myResume = new Resume();
        myResume._name = "Imegi Nmeri Zephaniah";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display resume
        myResume.Display();
    }
}