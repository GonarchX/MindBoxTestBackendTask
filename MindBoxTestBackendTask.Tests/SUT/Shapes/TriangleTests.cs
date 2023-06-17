using MindBoxTestBackendTask.Shapes;

namespace MindBoxTestBackendTask.Tests.SUT.Shapes;

public class TriangleTests
{
    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(10, 10, 14.14213)]
    [InlineData(9, 16, 18.35755)]
    public void IsRightRectangle_RightRectangle_ReturnTrue(double sideA, double sideB, double sideC)
    {
        // Arrange && Act && Assert
        Assert.True(new Triangle(sideA, sideB, sideC).IsRightTriangle());
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(3, 3, 5)]
    [InlineData(15, 30, 44)]
    public void IsRightRectangle_NotRightRectangle_ReturnFalse(double sideA, double sideB, double sideC)
    {
        // Arrange && Act && Assert
        Assert.False(new Triangle(sideA, sideB, sideC).IsRightTriangle());
    }

    [Theory]
    [InlineData(3, 3, 3)]
    [InlineData(4, 5, 5)]
    [InlineData(10, 50, 50)]
    [InlineData(123, 345, 234)]
    public void Constructor_ValidSides_CreateTriangle(double sideA, double sideB, double sideC)
    {
        // Arrange && Act
        var exception = Record.Exception(() => new Triangle(sideA, sideB, sideC));

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(-1, 1, 1)]
    [InlineData(-1, -1, 1)]
    [InlineData(-1, -1, -1)]
    [InlineData(1, 1, 3)]
    [InlineData(1, 1, 1234)]
    public void Constructor_InvalidSides_ThrowException(double sideA, double sideB, double sideC)
    {
        // Arrange && Act && Assert
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }
}