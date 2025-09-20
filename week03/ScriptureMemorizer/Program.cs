using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example scripture: Proverbs 3:5-6
            Reference reference = new Reference("Proverbs", 3, 5, 6);
            string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
            
            Scripture scripture = new Scripture(reference, text);

            // Loop until scripture is completely hidden or user types quit
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
                
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords();

                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nAll words are hidden. Program ending...");
                    break;
                }
            }
        }
    }
}

/*
CREATIVITY (Exceeded Requirements):
-----------------------------------
1. Program only hides words that are not already hidden (ensures fairness).
2. Added flexibility: number of words hidden per iteration can be changed
   by passing a parameter to HideRandomWords().
3. Handles multiple verses in the reference (Proverbs 3:5-6 style).
4. Uses Console.Clear() for a clean memorization experience.
*/
