using System;

namespace EternalQuest
{
    // A goal that never completes; each record gives points.
    public class EternalGoal : Goal
    {
        private int _timesRecorded;

        public EternalGoal(string name, int points) : base(name, points)
        {
            _timesRecorded = 0;
        }

        public override int RecordEvent()
        {
            _timesRecorded++;
            return Points;
        }

        public override string GetStatus()
        {
            return $"(Eternal) Completed {_timesRecorded} time(s)";
        }

        public override string Serialize()
        {
            // Format: Eternal|name|points|timesRecorded
            return $"Eternal|{Name}|{Points}|{_timesRecorded}";
        }

        public override void DeserializeState(string[] parts)
        {
            // parts expected: [Eternal, name, points, timesRecorded]
            if (parts.Length >= 4)
            {
                _timesRecorded = int.Parse(parts[3]);
            }
        }

        public override bool IsComplete() => false;
    }
}
