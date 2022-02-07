namespace MindBox.Geometry;

public static class Validator
{
    public static bool IsValidNumber(double number) => double.IsFinite(number) && !double.IsNaN(number);
    public static bool IsValidPositiveNumber(double number) => IsValidNumber(number) && number > 0.0;

    public static void ThrowIfNotValidPositiveNumber(double number, string paramName)
    {
        if (!IsValidPositiveNumber(number))
            throw new ValidationException($"Значение должно быть в пределах 0 < {paramName} < {double.MaxValue}",
                paramName);
    }
}