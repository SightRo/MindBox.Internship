namespace MindBox.Geometry;

public interface IShape
{
    double CalculateSquare();
}

public record Circle : IShape
{
    public double Radius { get; }

    private Circle(double radius)
    {
        Radius = radius;
    }

    public static Circle Create(double radius)
    {
        Validator.ThrowIfNotValidPositiveNumber(radius, nameof(radius));
        return new Circle(radius);
    }

    public double CalculateSquare() => Math.PI * Math.Pow(Radius, 2);
}

public record Triangle : IShape
{
    public double A { get; }
    public double B { get; }
    public double C { get; }
    public bool IsRight { get; }

    private Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
        IsRight = Math.Abs(Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) < double.Epsilon;
    }

    public static Triangle Create(double a, double b, double c)
    {
        Validator.ThrowIfNotValidPositiveNumber(a, nameof(a));
        Validator.ThrowIfNotValidPositiveNumber(b, nameof(b));
        Validator.ThrowIfNotValidPositiveNumber(c, nameof(c));

        var sortedValues = new List<double> { a, b, c };
        sortedValues.Sort();

        var ab = sortedValues[0] + sortedValues[1];
        if (!Validator.IsValidPositiveNumber(ab) || ab < sortedValues[2])
            throw new ValidationException("Треугольник должен удовлетворять условию a + b >= c.");

        return new Triangle(sortedValues[0], sortedValues[1], sortedValues[2]);
    }

    public double CalculateSquare()
    {
        // Heron's formula
        var s = (A + B + C) / 2;
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }
}