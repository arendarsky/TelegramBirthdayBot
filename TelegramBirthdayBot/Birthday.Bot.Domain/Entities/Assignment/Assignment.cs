using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday.Bot.Domain.Entities.Assignment
{
    public interface IAssignment
    {
        string Description { get; }
        string Suggestion { get; }
        bool IsAnswerCorrect(string answer);
    }

    public class Assignment : IAssignment
    {
        public Assignment(string description, string suggestion, IEnumerable<string> correctAnswers)
        {
            Description = description;
            CorrectAnswers = correctAnswers;
            Suggestion = suggestion;
        }

        protected IEnumerable<string> CorrectAnswers { get; }
        public string Description { get; }
        public string Suggestion { get; }

        public bool IsAnswerCorrect(string answer)
        {
            return CorrectAnswers.Any(correctAnswer =>
                correctAnswer.Equals(answer.Trim(), StringComparison.OrdinalIgnoreCase));
        }
    } 
}
