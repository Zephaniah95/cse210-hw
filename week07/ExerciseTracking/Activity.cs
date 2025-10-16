using System;

public abstract class Activity
{
    private string _date;
    private int _length; // in minutes

    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }

    public string GetDate() => _date;
    public int GetLength() => _length;

    // Abstract methods (to be overridden by derived classes)
    public abstract double GetDistance(); // in miles
    public abstract double GetSpeed();    // in mph
    public abstract double GetPace();     // in min per mile

    // Polymorphism: virtual method using overridden methods
    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_length} min) - " +
               $"Distance: {GetDistance():0.0} miles, " +
               $"Speed: {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.0} min per mile";
    }
}
