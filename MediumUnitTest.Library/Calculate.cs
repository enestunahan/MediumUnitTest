using MediumUnitTest.Library.Models;
using static MediumUnitTest.Library.Models.Enums;

namespace MediumUnitTest.Library
{
    public class Calculate
    {
        private List<string> _answers = new List<string>() { "C#", "JAVA", "JAVASCRIPT", "RUBY", "SWİFT" };
        public LetterGrade EvaluatePaper(AnswerPaper answerPaper)
        {
            if (string.IsNullOrEmpty(answerPaper.Student.FirstName))
                return LetterGrade.FF;


            int correctAnswersCount = CompareAnswers(answerPaper.Answers);
            
            if(correctAnswersCount == 4)
                return LetterGrade.BB;
            

            return LetterGrade.AA;
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
