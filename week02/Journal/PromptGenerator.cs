using System;
using System.Collections.Generic;

namespace JournalApp
{
    // Keeps the prompt list and returns random prompts
    public class PromptGenerator
    {
        private readonly List<string> _prompts;
        private readonly Random _random;

        public PromptGenerator()
        {
            _random = new Random();

            // You must have at least 5; I added more helpful ones.
            _prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What small win did I have today?",
                "What am I thankful for right now?",
                "What challenged me today and what did I learn?",
                "What made me smile today?",
                "What one task, if completed tomorrow, would make me proud?"
            };
        }

        public string GetRandomPrompt()
        {
            int idx = _random.Next(_prompts.Count);
            return _prompts[idx];
        }

        // Allows adding custom prompts (demonstrates extension)
        public void AddPrompt(string prompt)
        {
            if (!string.IsNullOrWhiteSpace(prompt)) _prompts.Add(prompt.Trim());
        }
    }
}
