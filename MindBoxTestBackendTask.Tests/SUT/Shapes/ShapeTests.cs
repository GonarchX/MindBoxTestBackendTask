using MindBoxTestBackendTask.Shapes;
using Xunit.Abstractions;

namespace MindBoxTestBackendTask.Tests.SUT.Shapes;

public class ShapeTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ShapeTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 3.141593)]
    [InlineData(5, 78.54)]
    [InlineData(124, 48305.128)]
    public void CalculateArea_Circle_ReturnsCircleArea(double circleRadius, double expectedArea)
    {
        // Arrange
        Circle circle = new Circle(circleRadius);

        // Act
        double calculatedArea = circle.CalculateArea();

        _testOutputHelper.WriteLine($"Calculated area: {calculatedArea}");
        _testOutputHelper.WriteLine($"Expected area: {expectedArea}");

        // Assert
        Assert.True(Math.Abs(expectedArea - calculatedArea) < Constants.ShapeAreaPrecision);
    }

    [Theory]
    [InlineData(1, 2, 2, 0.9682)]
    [InlineData(3, 4, 5, 6)]
    [InlineData(9, 12, 16, 53.4409)]
    [InlineData(11111, 11111, 2, 11110.9999)]
    public void CalculateArea_Triangle_ReturnsTriangleArea(
        double sideA,
        double sideB,
        double sideC,
        double expectedArea)
    {
        // Arrange
        Shape square = new Triangle(sideA, sideB, sideC);

        // Act
        double calculatedArea = square.CalculateArea();

        _testOutputHelper.WriteLine($"Calculated area: {calculatedArea}");
        _testOutputHelper.WriteLine($"Expected area: {expectedArea}");

        // Assert
        Assert.True(Math.Abs(expectedArea - calculatedArea) < Constants.ShapeAreaPrecision);
    }
}