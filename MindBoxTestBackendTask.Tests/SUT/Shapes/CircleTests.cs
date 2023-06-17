using System.Reflection.Metadata;
using MindBoxTestBackendTask.Shapes;

namespace MindBoxTestBackendTask.Tests.SUT.Shapes;

public class CircleTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(9999)]
    public void Constructor_ValidRadius_CreateCircle(double circleRadius)
    {
        // Arrange && Act
        var exception = Record.Exception(() => new Circle(circleRadius));

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(-999)]
    [InlineData(-5)]
    [InlineData(-4)]
    [InlineData(-1)]
    public void Constructor_InvalidRadius_ThrowException(double circleRadius)
    {
        // Arrange && Act && Assert
        Assert.Throws<ArgumentException>(() => new Circle(circleRadius));
    }
}