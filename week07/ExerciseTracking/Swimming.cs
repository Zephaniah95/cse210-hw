using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int length, int laps)
        : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double distanceMeters = _laps * 50; // 50 meters per lap
        double distanceMiles = distanceMeters / 1000 * 0.62;
        return distanceMiles;
    }

    public override double GetSpeed() => (GetDistance() / GetLength()) * 60;

    public override double GetPace() => GetLength() / GetDistance();
}
