using System;

namespace Week03Project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using all 3 constructors
            Fraction f1 = new Fraction();
            Console.WriteLine(f1.GetFractionString());
            Console.WriteLine(f1.GetDecimalValue());

            Fraction f2 = new Fraction(5);
            Console.WriteLine(f2.GetFractionString());
            Console.WriteLine(f2.GetDecimalValue());

            Fraction f3 = new Fraction(3, 4);
            Console.WriteLine(f3.GetFractionString());
            Console.WriteLine(f3.GetDecimalValue());

            Fraction f4 = new Fraction(1, 3);
            Console.WriteLine(f4.GetFractionString());
            Console.WriteLine(f4.GetDecimalValue());

            // Using setters
            f4.SetTop(2);
            f4.SetBottom(5);
            Console.WriteLine(f4.GetFractionString()); // 2/5
            Console.WriteLine(f4.GetDecimalValue());   // 0.4
        }
    }
}
