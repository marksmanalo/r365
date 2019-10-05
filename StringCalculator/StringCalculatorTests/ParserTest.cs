﻿using System;
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
        public void MoreThanTwoInputs()
        {

            var expectedResult = new List<int>() { 1, 5000, -3, 4, 0 };

            var parser = new Parser();

            var result = parser.Parse("1,5000,-3,4,rtr");

            Assert.IsTrue(expectedResult.SequenceEqual(result));

        }

        [TestMethod]
        public void MoreThanTwoInputs_Test2()
        {

            var expectedResult = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            var parser = new Parser();

            var result = parser.Parse("1,2,3,4,5,6,7,8,9,10,11,12");

            Assert.IsTrue(expectedResult.SequenceEqual(result));

        }
    }
}
