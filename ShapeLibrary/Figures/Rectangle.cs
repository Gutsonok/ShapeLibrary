using ShapeLibrary.Abstractions;

namespace ShapeLibrary.Figures;

public class Rectangle : IShape
{
    private readonly double _height;
    
    private readonly double _width;
    
    private readonly double _area;
    
    public Rectangle(double height, double width)
    {
        if (height <= 0) throw new ArgumentException("The height should be greater than zero");
        if (width <= 0) throw new ArgumentException("The width should be greater than zero");

        _height = height;
        _width = width;
        _area = _height * _width; 
    }

    public double Area => _area;
}