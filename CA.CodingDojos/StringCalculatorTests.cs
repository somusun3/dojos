using System;
using NUnit.Framework;

namespace CA.CodingDojos
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator calculator;
        [SetUp]
        public void Setup()
        {
            calculator = new StringCalculator();
        }

        [TestCase("", 0, "Empty string should return 0")]
        [TestCase("1", 1, "Single number string should return that number")]
        [TestCase("1,2", 3, "Two number string should return their sum")]
        [TestCase("1,2,3", 6, "Multiple number string should return their sum")]
        [TestCase("1\n2,3", 6, "Should be able to use newline as a delimiter instead of comma")]
        [TestCase("//;1;2,3", 6, "Should be able to use custom delimiters instead of comma")]
        public void TestForPositiveNumbers(string input, int expected, string message)
        {
            var result = calculator.Add(input);
            Assert.AreEqual(expected, result, message);
        }

        [TestCase("-1,2", "Negatives not allowed. Input contains '-1'.", "Single negative number throws an exception with the number in the message")]
        [TestCase("-1,-2", "Negatives not allowed. Input contains '-1, -2'.", "Multiple negative numbers throws an exception with the number in the message")]
        public void TestNegativeNumberShouldThrowAnException(string input, string exceptionMessage, string message)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.Add(input), exceptionMessage);
        }
    }
}
