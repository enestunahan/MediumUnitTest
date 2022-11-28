using MediumUnitTest.Library;
using MediumUnitTest.Library.Models;
using static MediumUnitTest.Library.Models.Enums;

namespace MediumUnitTest.Test
{
    public class CalculateTest
    {
        [Fact]
        public void EvaluatePaper_NameAndSurnameNull_ReturnLetterGradeFF()
        {
            //Arrange

            var calculate = new Calculate();
            var answerPaper = new AnswerPaper
            {
                Student = new Student
                {
                    FirstName = ""
                }
            };

            //Action
            
            var testResult  = calculate.EvaluatePaper(answerPaper);

            //Assert

            Assert.Equal(LetterGrade.FF, testResult);
        }


        [Theory]
        [InlineData("C#", "JAVA", "JAVASCRIPT", "RUBY", "c++")]
        public void EvaulatePaper_FourCorrectAnswer_ReturnsLetterGradeBb(string ans1  ,string ans2 , string ans3,string ans4 ,string ans5)
        {
            var calculate = new Calculate();

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

            var testResult = calculate.EvaluatePaper(answerPaper);

            Assert.Equal(LetterGrade.BB,testResult);
        }

    }
}
