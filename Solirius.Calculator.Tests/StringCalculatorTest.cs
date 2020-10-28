using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solirius.Calculator.Exceptions;
using System;

namespace Solirius.Calculator.Tests
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void TestAddEmptryString()
        {
            var numbers = "";
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(numbers);
            result.Should().Be(0);
        }

        [TestMethod]
        public void TestAddOneNumber()
        {
            var numbers = "1";
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(numbers);
            result.Should().Be(1);
        }

        [TestMethod]
        public void TestAddTwoNumber()
        {
            var numbers = "1,2";
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(numbers);
            result.Should().Be(3);
        }

        [TestMethod]
        public void TestAddNumbers()
        {
            var numbers = "1,2,3";
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(numbers);
            result.Should().Be(6);
        }

        [TestMethod]
        public void TestAddNumbersWithMultipleSeparators()
        {
            var numbers = "1\n2,3";
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(numbers);
            result.Should().Be(6);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddNumbersWithInvalidSeparator()
        {
            var numbers = "1,\n";
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(numbers);
        }

        [TestMethod]
        public void TestAddNumbersWithCustomSeparator()
        {
            var numbers = "//;\n1;2";
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(numbers);
            result.Should().Be(3);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativesNotAllowedException))]
        public void TestAddNumbersWithNegativeNumbers()
        {
            var numbers = "1,-2,-3";
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(numbers);
        }

        [TestMethod]
        public void TestAddNumbersWithNumbersToIgnore()
        {
            var numbers = "2,1001,13";
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(numbers);
            result.Should().Be(15);
        }

        [TestMethod]
        public void TestAddNumbersWithMultipeCustomSeparators()
        {
            var numbers =  "//*%\n1*2%3";
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(numbers);
            result.Should().Be(6);
        }
    }
}
