using ShapeLibrary.Abstractions;

namespace ShapeLibrary.Figures
{
    public class Circle : IShape
    {
        private readonly double _radius;

        private readonly double _area;

        public Circle(double radius)
        {
            if (radius <= 0) throw new ArgumentException("The radius should be greater than zero");

            _radius = radius;
            _area = Math.PI * _radius * _radius; 
        }

        public double Area => _area;
    }
}
