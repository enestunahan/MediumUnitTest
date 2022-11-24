using MediumUnitTest.Library.Models;
using static MediumUnitTest.Library.Models.Enums;

namespace MediumUnitTest.Library
{
    public class Calculate
    {
        public LetterGrade EvaluatePaper(AnswerPaper answer)
        {
            if (string.IsNullOrEmpty(answer.Student.FirstName))
                return LetterGrade.FF;
            
                
            return LetterGrade.AA;
        }
    }
}
