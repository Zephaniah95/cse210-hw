using System;

namespace EternalQuest
{
    // A checklist that needs to be recorded a certain number of times to be complete.
    // Each time gives base points; on the final required recording, a bonus is awarded.
    public class ChecklistGoal : Goal
    {
        private int _requiredCount;
        private int _timesCompleted;
        private int _bonusPoints;
        private bool _completed;

        public ChecklistGoal(string name, int points, int requiredCount, int bonusPoints) : base(name, points)
        {
            _requiredCount = requiredCount;
            _bonusPoints = bonusPoints;
            _timesCompleted = 0;
            _completed = false;
        }

        public override int RecordEvent()
        {
            if (_completed)
            {
                Console.WriteLine("Checklist goal already completed.");
                return 0;
            }

            _timesCompleted++;
            int reward = Points;

            if (_timesCompleted >= _requiredCount)
            {
                _completed = true;
                reward += _bonusPoints;
            }

            return reward;
        }

        public override string GetStatus()
        {
            return $"Completed {_timesCompleted}/{_requiredCount} {( _completed ? "[X]" : "[ ]")}";
        }

        public override string Serialize()
        {
            // Format: Checklist|name|points|requiredCount|bonus|timesCompleted|completed
            return $"Checklist|{Name}|{Points}|{_requiredCount}|{_bonusPoints}|{_timesCompleted}|{_completed}";
        }

        public override void DeserializeState(string[] parts)
        {
            // parts expected: [Checklist, name, points, requiredCount, bonus, timesCompleted, completed]
            if (parts.Length >= 7)
            {
                _requiredCount = int.Parse(parts[3]);
                _bonusPoints = int.Parse(parts[4]);
                _timesCompleted = int.Parse(parts[5]);
                _completed = bool.Parse(parts[6]);
            }
        }

        public override bool IsComplete() => _completed;
    }
}
