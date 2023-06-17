namespace MindBoxTestBackendTask.Shapes;

public class Triangle : Shape
{
    private const double Eps = 0.001;
    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        ValidateTriangleSides(sideA, sideB, sideC);

        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }

    public override double CalculateArea()
    {
        var s = CalculateSemiperimeter();
        return Math.Sqrt(s * (s - _sideA) * (s - _sideB) * (s - _sideC));
    }

    public bool IsRightTriangle()
    {
        double a2 = Math.Pow(_sideA, 2);
        double b2 = Math.Pow(_sideB, 2);
        double c2 = Math.Pow(_sideC, 2);

        /*
            Оригинальные условия проверки "прямоугольности" треугольника выглядят следующим образом:
            sideA^2 + sideB^2 == sideC^2
            и далее по аналогии для сторон "B" и "C".
           
            Однако, т.к. мы работаем с числами с плавающей точкой, возможна ситуация,
            когда из-за погрешности работы с дробной части
            сумма двух сторон, эквивалентная третьей стороне, не будет равна ей в нашей программе.
           
            Для избежания этой ситуации необходимо использовать допустимую погрешность (eps)
        */
        
        return Math.Abs(a2 + b2 - c2) < Eps ||
               Math.Abs(a2 + c2 - b2) < Eps ||
               Math.Abs(b2 + c2 - a2) < Eps;
    }

    private double CalculateSemiperimeter() => (_sideA + _sideB + _sideC) / 2;

    // Метод проверяющий корректность треугольника с заданными сторонами
    private static void ValidateTriangleSides(double sideA, double sideB, double sideC)
    {
        var negativeSideSizeMessage = "Сторона треугольника должна быть больше 0";
        if (sideA <= 0)
            throw new ArgumentException(negativeSideSizeMessage, nameof(sideA));
        if (sideB <= 0)
            throw new ArgumentException(negativeSideSizeMessage, nameof(sideB));
        if (sideC <= 0)
            throw new ArgumentException(negativeSideSizeMessage, nameof(sideC));

        var av = "Сумма двух сторон треугольника должна быть больше третьей стороны";
        if (sideB + sideC <= sideA)
            throw new ArgumentException(av, nameof(sideA));
        if (sideA + sideC <= sideB)
            throw new ArgumentException(av, nameof(sideB));
        if (sideA + sideB <= sideC)
            throw new ArgumentException(av, nameof(sideC));
    }
}