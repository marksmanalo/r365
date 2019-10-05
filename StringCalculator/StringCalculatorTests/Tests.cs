using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StringCalculator.Services;

namespace StringCalculatorTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void InitialTest()
        {
            var mockParser = new Mock<IParser>();
            mockParser.Setup(x => x.Parse()).Returns("Hello Tests");

            var calculator = new MarksStringCalculator(mockParser.Object);

            var result = calculator.HelloWorld();
            Assert.AreEqual("Hello Tests", result);
        }
    }
}
