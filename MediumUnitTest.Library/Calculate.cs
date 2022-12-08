using MediumUnitTest.Library.Models;
using MediumUnitTest.Library.Services;
using static MediumUnitTest.Library.Models.Enums;

namespace MediumUnitTest.Library
{
    public class Calculate
    {       
        private List<string> _answers = new List<string>() { "C#", "JAVA", "JAVASCRIPT", "RUBY", "SWİFT" };
        private readonly IIdentityValidator _validator;

        public Calculate(IIdentityValidator validator)
        {
            _validator = validator;
        }

        public LetterGrade EvaluatePaper(AnswerPaper answerPaper)
        {
            if (string.IsNullOrEmpty(answerPaper.Student.FirstName))
                return LetterGrade.FF;

            if (_validator.IsValid(answerPaper.Student.FullName))
            {   
                int correctAnswersCount = CompareAnswers(answerPaper.Answers);
            
                if (correctAnswersCount == 4)
                return LetterGrade.BB;
            }

            return LetterGrade.FF;
        }

        private int CompareAnswers(List<string> answers)
        {
            var matchedCounts = answers.
                                Where(i => _answers.Contains(i, StringComparer.OrdinalIgnoreCase)).
                                Count();           
            return matchedCounts;           
        } 
    }
}
