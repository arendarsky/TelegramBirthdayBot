using System;
using System.Collections.Generic;
using System.Linq;
using Birthday.Bot.Domain.DataInterfaces.Assignment;

namespace Birthday.Bot.Domain.Entities.Assignment
{
    public interface IAssignment
    {
        string Description { get; }
        bool IsAnswerCorrect(string answer);
    }

    public class Assignment : IAssignment
    {
        public Assignment(string description, IEnumerable<string> correctAnswers)
        {
            Description = description;
            CorrectAnswers = correctAnswers;
        }

        protected IEnumerable<string> CorrectAnswers { get; }
        public string Description { get; }

        public bool IsAnswerCorrect(string answer)
        {
            return CorrectAnswers.Any(correctAnswer =>
                correctAnswer.Equals(answer.Trim(), StringComparison.OrdinalIgnoreCase));
        }
    } 
}
