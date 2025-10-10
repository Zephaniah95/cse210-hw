using System;

namespace EternalQuest
{
    // A goal that can be completed once (gives points once).
    public class SimpleGoal : Goal
    {
        private bool _completed;

        public SimpleGoal(string name, int points) : base(name, points)
        {
            _completed = false;
        }

        public override int RecordEvent()
        {
            if (_completed)
            {
                Console.WriteLine("This goal is already completed.");
                return 0;
            }
            _completed = true;
            return Points;
        }

        public override string GetStatus()
        {
            return _completed ? "[X]" : "[ ]";
        }

        public override string Serialize()
        {
            // Format: Simple|name|points|completed
            return $"Simple|{Name}|{Points}|{_completed}";
        }

        public override void DeserializeState(string[] parts)
        {
            // parts expected: [Simple, name, points, completed]
            if (parts.Length >= 4)
            {
                _completed = bool.Parse(parts[3]);
            }
        }

        public override bool IsComplete() => _completed;
    }
}
