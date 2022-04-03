using NUnit.Framework;
using ShapeLibrary.Abstractions;
using ShapeLibrary.Figures;
using System;

namespace ShapeLibraryTests.FiguresTests
{
    public class CircleTests
    {
        [TestCase(0)]
        [TestCase(-4)]
        public void Constructor_NotValidParameters_ShouldReturnException(double radius)
        {
            // Act
            var exception = Assert.Throws<ArgumentException>(() => new Circle(radius));

            // Assert
            Assert.AreEqual("The radius should be greater than zero", exception.Message);
        }

        [TestCase(3, 28.274334)]
        [TestCase(10, 314.159265)]
        public void GetArea_ShouldReturnCorrectArea(double radius, double result)
        {
            // Assert
            IShape triangle = new Circle(radius);

            // Act
            var area = triangle.Area;

            // Arrange
            Assert.AreEqual(result, area, 0.000001);
        }
    }
}
