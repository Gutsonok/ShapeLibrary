using NUnit.Framework;
using ShapeLibrary.Abstractions;
using ShapeLibrary.Figures;
using System;

namespace ShapeLibraryTests.FiguresTests
{
    public class TriangleTests
    {
        [TestCase(-3, 4, 5, "sideA")]
        [TestCase(0, 4, 5, "sideA")]
        [TestCase(3, -4, 5, "sideB")]
        [TestCase(3, 0, 5, "sideB")]
        [TestCase(3, 4, -5, "sideC")]
        [TestCase(3, 4, 0, "sideC")]
        public void Constructor_NotValidParameters_ShouldReturnException(double sideA, double sideB, double sideC, string sideName)
        {
            // Act
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));

            // Assert
            Assert.AreEqual($"The side length ({sideName}) of the triangle must be be greater than zero", exception.Message);
        }


        [TestCase(3, 4, 1)]
        [TestCase(1, 3, 4)]
        [TestCase(4, 1, 3)]
        public void Constructor_InequalityTriangleIsNotExecuted_ShouldReturnException(double sideA, double sideB, double sideC)
        {
            // Act
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));

            // Assert
            Assert.AreEqual("The triangle inequality must be executed", exception.Message);
        }

        [TestCase(3, 4, 5)]
        public void Constructor_InequalityTriangleIsExecuted_ShouldReturnTriangle(double sideA, double sideB, double sideC)
        {
            Assert.DoesNotThrow(() => new Triangle(sideA, sideB, sideC));
        }

        [TestCase(3, 4, 5, 6)]
        [TestCase(10, 12, 7, 34.977671)]
        public void GetArea_ShouldReturnCorrectArea(double sideA, double sideB, double sideC, double result)
        {
            // Assert
            IShape triangle = new Triangle(sideA, sideB, sideC);

            // Act
            var area = triangle.Area;

            // Arrange
            Assert.AreEqual(result, area, 0.000001);
        }

        [TestCase(3, 4, 5)]
        [TestCase(3, 5, 4)]
        [TestCase(4, 3, 5)]
        [TestCase(4, 5, 3)]
        [TestCase(5, 4, 3)]
        [TestCase(5, 3, 4)]
        public void IsRight_ShouldReturnTrue(double sideA, double sideB, double sideC)
        {
            // Assert
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act
            var isTriangle = triangle.IsRight();

            // Arrange
            Assert.IsTrue(isTriangle);
        }

        [TestCase(5, 4, 5)]
        public void IsRight_ShouldReturnFalse(double sideA, double sideB, double sideC)
        {
            // Assert
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act
            var isTriangle = triangle.IsRight();

            // Arrange
            Assert.IsFalse(isTriangle);
        }
    }
}