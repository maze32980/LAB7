using System.Numerics;
using Mi_Labs_2;


namespace Mi_Labs_2_Test
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_Integers_ReturnsCorrectResult()
        {
            // Arrange
            var calculator = new Calculator<BigInteger>();
            var a = new BigInteger(5);
            var b = new BigInteger(10);

            // Act
            var result = calculator.Add(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(new BigInteger(15)));
        }

        [Test]
        public void Subtract_Integers_ReturnsCorrectResult()
        {
            // Arrange
            var calculator = new Calculator<BigInteger>();
            var a = new BigInteger(10);
            var b = new BigInteger(5);

            // Act
            var result = calculator.Subtract(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(new BigInteger(5)));
        }

        [Test]
        public void Multiply_Integers_ReturnsCorrectResult()
        {
            // Arrange
            var calculator = new Calculator<BigInteger>();
            var a = new BigInteger(5);
            var b = new BigInteger(10);

            // Act
            var result = calculator.Multiply(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(new BigInteger(50)));
        }

        [Test]
        public void Divide_Integers_ReturnsCorrectResult()
        {
            // Arrange
            var calculator = new Calculator<BigInteger>();
            var a = new BigInteger(10);
            var b = new BigInteger(5);

            // Act
            var result = calculator.Divide(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(new BigInteger(2)));
        }
    }
}
