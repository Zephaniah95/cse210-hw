using System;

class Program
{
    static void Main(string[] args)
    {
        // Test base Assignment
        Assignment a1 = new Assignment("Imegi Nmeri Zephaniah", "Multiplication");
        Console.WriteLine(a1.GetSummary());
        Console.WriteLine();

        // Test MathAssignment
        MathAssignment m1 = new MathAssignment("Fredshed Catherine", "Fractions", "7.3", "8-19");
        Console.WriteLine(m1.GetSummary());
        Console.WriteLine(m1.GetHomeworkList());
        Console.WriteLine();

        // Test WritingAssignment
        WritingAssignment w1 = new WritingAssignment("Christopher Fredshed", "Zoology", "The Role of Pollinators in Biodiversity Conservation");
        Console.WriteLine(w1.GetSummary());
        Console.WriteLine(w1.GetWritingInformation());
    }
}
