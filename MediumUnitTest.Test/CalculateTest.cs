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
    }
}
