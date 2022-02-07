using NUnit.Framework;

namespace MindBox.Geometry.Tests;

[TestFixture]
public class CircleTests
{
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(double.NaN)]
    [TestCase(double.PositiveInfinity)]
    [TestCase(double.NegativeInfinity)]
    public void CreatingFromIncorrectValueThrowsValidation(double radius)
    {
        Assert.Throws<ValidationException>(() => Circle.Create(radius));
    }
}