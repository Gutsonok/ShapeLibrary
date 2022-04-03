using ShapeLibrary.Abstractions;

namespace ShapeLibrary.Figures
{
    public class Triangle : IShape
    {
        private readonly double _sideA;

        private readonly double _sideB;

        private readonly double _sideC;

        private readonly double _area;

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0) throw new ArgumentException($"The side length ({nameof(sideA)}) of the triangle must be be greater than zero");
            if (sideB <= 0) throw new ArgumentException($"The side length ({nameof(sideB)}) of the triangle must be be greater than zero");
            if (sideC <= 0) throw new ArgumentException($"The side length ({nameof(sideC)}) of the triangle must be be greater than zero");

            if (sideA >= sideB + sideC || sideB >= sideA + sideC || sideC >= sideA + sideB) throw new ArgumentException("The triangle inequality must be executed");

            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;

            _area = CalculateArea();
        }

        public double Area => _area;

        public bool IsRight()
        {
            return _sideA * _sideA == _sideB * _sideB + _sideC * _sideC
                || _sideB * _sideB == _sideA * _sideA + _sideC * _sideC
                || _sideC * _sideC == _sideA * _sideA + _sideB * _sideB;
        }

        private double CalculateArea()
        {
            var semiperimeter = (_sideA + _sideB + _sideC) / 2.0;
            return Math.Sqrt(semiperimeter * (semiperimeter - _sideA) * (semiperimeter - _sideB) * (semiperimeter - _sideC));
        }
    }
}