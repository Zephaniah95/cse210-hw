using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            foreach (string word in text.Split(" "))
            {
                _words.Add(new Word(word));
            }
            _random = new Random();
        }

        public void HideRandomWords(int numberToHide = 3)
        {
            int hiddenCount = 0;
            while (hiddenCount < numberToHide)
            {
                int index = _random.Next(_words.Count);
                if (!_words[index].IsHidden())
                {
                    _words[index].Hide();
                    hiddenCount++;
                }
            }
        }

        public string GetDisplayText()
        {
            List<string> displayWords = new List<string>();
            foreach (Word word in _words)
            {
                displayWords.Add(word.GetDisplayText());
            }
            return $"{_reference.GetDisplayText()} - {string.Join(" ", displayWords)}";
        }

        public bool IsCompletelyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
