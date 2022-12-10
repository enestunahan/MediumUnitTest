using MediumUnitTest.Library;
using MediumUnitTest.Library.Models;
using MediumUnitTest.Library.Services;
using Moq;
using static MediumUnitTest.Library.Models.Enums;

namespace MediumUnitTest.Test
{
    public class CalculateTest
    {

        private readonly Calculate _calculate;
        private readonly Mock<IIdentityValidator> _mock;

        public CalculateTest()
        {
           _mock = new Mock<IIdentityValidator>();
           _calculate = new Calculate(_mock.Object);
        }


        [Fact]
        public void EvaluatePaper_NameAndSurnameNull_ReturnLetterGradeFF()
        {
            //Arrange
            var answerPaper = new AnswerPaper
            {
                Student = new Student
                {
                    FirstName = ""
                }
            };

            //Action          
            var testResult  = _calculate.EvaluatePaper(answerPaper);

            //Assert
            Assert.Equal(LetterGrade.FF, testResult);
        }


        [Theory]
        [InlineData("C#", "JAVA", "JAVASCRIPT", "RUBY", "c++")]
        public void EvaulatePaper_FourCorrectAnswer_ReturnsLetterGradeBb(string ans1  ,string ans2 , string ans3,string ans4 ,string ans5)
        {           

            var answerPaper = new AnswerPaper
            {
                Student = new Student
                {
                    FirstName = "Enes"
                },
                Answers = new List<string>
                {
                    ans1,ans2,ans3,ans4,ans5
                }
            };

            _mock.Setup(x=>x.IsValid(answerPaper.Student.FullName)).Returns(true);

            var testResult = _calculate.EvaluatePaper(answerPaper);

            Assert.Equal(LetterGrade.BB,testResult);

            _mock.Verify(x => x.IsValid(answerPaper.Student.FullName), Times.Once);
        }

        [Fact]
        public void EvaulatePaper_FullNameLengthLessThanFive_ReturnsException()
        {
            var answerPaper = new AnswerPaper
            {
                Student = new Student { FirstName = "e", LastName = "bb" }
            };

            _mock.Setup(x => x.IsValid(answerPaper.Student.FullName)).Throws(new Exception("FullName alanı 5 karakterden fazla olmalıdır"));

            Exception exception = Assert.Throws<Exception>(()=> _calculate.EvaluatePaper(answerPaper));

            Assert.Equal("FullName alanı 5 karakterden fazla olmalıdır", exception.Message);
        }



    }
}
