namespace MindBoxTestBackendTask.Shapes;

public class Circle : Shape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        ValidateCircleRadius(radius);
        
        _radius = radius;
    }

    public override double CalculateArea() => Math.PI * Math.Pow(_radius, 2);

    private void ValidateCircleRadius(double radius)
    {
        if (radius < 0)
            throw new ArgumentException("Радиус круга должен быть больше, либо равен 0", nameof(radius));
    }
}