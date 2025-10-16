using System;

public class Running : Activity
{
    private double _distance; // miles

    public Running(string date, int length, double distance)
        : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (GetDistance() / GetLength()) * 60;

    public override double GetPace() => GetLength() / GetDistance();
}
