using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StringCalculator.Services;
using System.Collections.Generic;

namespace StringCalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void SingleInput()
        {
            var expectedResult = new List<int>() { 20 };
            var mockParser = new Mock<IParser>();
            mockParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(expectedResult);

            var calculator = new MarksStringCalculator(mockParser.Object);

            var result = calculator.Add("20");
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void TwoInputs_Test1()
        {
            var expectedResult = new List<int>() { 1, 5000 };
            var mockParser = new Mock<IParser>();
            mockParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(expectedResult);

            var calculator = new MarksStringCalculator(mockParser.Object);

            var result = calculator.Add("1,5000");
            Assert.AreEqual(5001, result);
        }

        [TestMethod]
        public void TwoInputs_Test2()
        {
            var expectedResult = new List<int>() { 4, -3 };
            var mockParser = new Mock<IParser>();
            mockParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(expectedResult);

            var calculator = new MarksStringCalculator(mockParser.Object);

            var result = calculator.Add("4,-3");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void AlotOfInputs()
        {
            var expectedResult = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var mockParser = new Mock<IParser>();
            mockParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(expectedResult);

            var calculator = new MarksStringCalculator(mockParser.Object);

            var result = calculator.Add("1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12");
            Assert.AreEqual(78, result);
        }

    }
}
