using System;

namespace EternalQuest
{
    // Base class for all goals
    public abstract class Goal
    {
        private string _name;
        private int _points; // points given when an event is recorded (base)
        public string Name => _name;
        public int Points => _points;

        protected Goal(string name, int points)
        {
            _name = name;
            _points = points;
        }

        // Called when the user records that they've completed/advanced this goal.
        // Returns total points awarded for this event (may include bonus).
        public abstract int RecordEvent();

        // Returns a display string that shows the goal's completion/progress status
        public abstract string GetStatus();

        // Serialize to a simple line format (we'll use GoalManager to save/load)
        public abstract string Serialize();

        // Populate state from parts from Deserialize (used by GoalManager)
        public abstract void DeserializeState(string[] parts);

        // Whether the goal is completed (for goals that can finish)
        public abstract bool IsComplete();
    }
}
