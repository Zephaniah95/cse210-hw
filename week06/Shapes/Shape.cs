using System;

public class Shape
{
    // Common attribute for all shapes
    private string _color;

    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    // Getter and Setter for color
    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual method to be overridden by subclasses
    public virtual double GetArea()
    {
        return 0; // Default (will be overridden)
    }
}
