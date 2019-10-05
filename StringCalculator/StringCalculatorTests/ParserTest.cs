using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Services;

namespace StringCalculatorTests
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void SingleNumber()
        {

            var expectedResult = new List<int>() { 20 };

            var parser = new Parser();

            var result = parser.Parse("20");

            Assert.IsTrue(expectedResult.SequenceEqual(result));

        }

        [TestMethod]
        public void TwoInputs()
        {
            var expectedResult = new List<int>() { 1, 5000 };

            var parser = new Parser();

            var result = parser.Parse("1,5000");

            Assert.IsTrue(expectedResult.SequenceEqual(result));

        }

        [TestMethod]
        public void EmptyAndMissingInputs()
        {
            var expectedResult = new List<int>() { 1, 0 };

            var parser = new Parser();

            var result = parser.Parse("1,");

            Assert.IsTrue(expectedResult.SequenceEqual(result));

        }

        [TestMethod]
        public void InvalidNumbers()
        {
            var expectedResult = new List<int>() { 13, 0 };

            var parser = new Parser();

            var result = parser.Parse("13,fefefef");

            Assert.IsTrue(expectedResult.SequenceEqual(result));

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void MoreThanTwoInputs()
        {

            var parser = new Parser();

            parser.Parse("13,2,3");

        }
    }
}
