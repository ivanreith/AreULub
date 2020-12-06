using AreULub.Models;
using System;
using Xunit;

namespace AreULubTests
{
    public class QuickReviewTest
    {
        [Fact]
        public void TestReviewLow()
        {
            //Arrange
            var quickReview = new QuickReview()
            {
                UserQuesting = "Tester",
                Quest1 = "1",
                Quest2 = "1",
                Quest3 = "1"
            };

            //Act
            string resultReview = quickReview.CheckQuiz(quickReview);

            //Assert
            Assert.Equal("Sorry we didn't match your expectations!", quickReview.Quest2AnswerRight);
        }
        [Fact]
        public void TestReviewHigh()
        {
            //Arrange
            var quickReview = new QuickReview()
            {
                UserQuesting = "Tester",
                Quest1 = "3",
                Quest2 = "3",
                Quest3 = "3"
            };

            //Act
            string resultReview = quickReview.CheckQuiz(quickReview);

            //Assert
            Assert.Equal("We are glad that you enjoyed our service, please come back!", quickReview.Quest2AnswerRight);
        }
    }
}
