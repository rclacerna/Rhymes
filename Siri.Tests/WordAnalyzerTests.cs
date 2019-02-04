using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using Siri.Interfaces;
using Siri;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void TestFindRhymes_EnterValidInput_ReturnsBestMatch()
        {
            // arrange
            var input = "Strange";
            var data = new Mock<IData>();
            var mockData = new Dictionary<string, int>
            {
                {"Orange", 0 },
                {"Dogs", 0 },
                {"Lounge", 0 }
            };

            // act
            data.Setup(x => x.WordsCollection()).Returns(mockData);
            var sut = new WordAnalyzer(data.Object);
            var testResult = sut.FindRhymes(input);

            // assert
            Assert.AreEqual(testResult[0], "Orange");
        }

        [Test]
        public void TestFindRhymes_EnterEmptyString_ReturnsNull()
        {
            // arrange
            var input = " ";
            var data = new Mock<IData>();
            var mockData = new Dictionary<string, int>
            {
                {"Orange", 0 },
                {"Dogs", 0 },
                {"Strange", 0 }
            };
            // act
            data.Setup(x => x.WordsCollection()).Returns(mockData);
            var sut = new WordAnalyzer(data.Object);
            var testResult = sut.FindRhymes(input);

            // assert
            Assert.AreEqual(testResult, null);
        }
    }
}