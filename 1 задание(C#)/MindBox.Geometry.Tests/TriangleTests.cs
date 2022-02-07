using System;
using NUnit.Framework;

namespace MindBox.Geometry.Tests;

[TestFixture]
public class TriangleTests
{
    [TestCase(-1, 3, 5)]
    [TestCase(7, -3, 5)]
    [TestCase(7, 3, -7)]
    public void CreatingFromNegativeValuesThrowsValidation(double a, double b, double c)
    {
        Assert.Throws<ValidationException>(() => Triangle.Create(a, b, c));
    }

    [TestCase(0, 3, 5)]
    [TestCase(7, 0, 5)]
    [TestCase(7, 3, 0)]
    public void CreatingFromZeroValuesThrowsValidation(double a, double b, double c)
    {
        Assert.Throws<ValidationException>(() => Triangle.Create(a, b, c));
    }
    
    [TestCase(0, 3, double.NaN)]
    [TestCase(7, double.NegativeInfinity, 5)]
    [TestCase(double.PositiveInfinity, 3, 0)]
    public void CreatingFromIncorrectValuesThrowsValidation(double a, double b, double c)
    {
        Assert.Throws<ValidationException>(() => Triangle.Create(a, b, c));
    }

    [TestCase(20, 3, 5)]
    [TestCase(7, 13, 5)]
    [TestCase(7, 3, 11)]
    public void CreatingFromIncorrectInputThrowsValidation(double a, double b, double c)
    {
        Assert.Throws<ValidationException>(() => Triangle.Create(a, b, c));
    }

    [TestCase(5, 3, 4, true)]
    [TestCase(7, 9, 3, false)]
    public void CheckIsRightProperty(double a, double b, double c, bool expected)
    {
        var triangle = Triangle.Create(a, b, c);
        Assert.AreEqual(triangle.IsRight, expected);
    }
    
    [TestCase(2, 1, 1)]
    [TestCase(1, 2, 1)]
    [TestCase(1, 1, 2)]
    public void CIsAlwaysHypotenuse(double a, double b, double c)
    {
        var triangle = Triangle.Create(a, b, c);
        Assert.AreEqual(triangle.C, Math.Max(a, Math.Max(b, c)));
    }
}