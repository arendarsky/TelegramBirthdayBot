using System.Collections.Generic;
using Birthday.Bot.Domain.Entities.Assignment;

namespace Birthday.Bot.Domain.Entities.Stage
{
    public interface IStage
    {
        int Order { get; }
        bool IsCompleted { get; }
        bool IsSuccessful { get; }
        string AssignmentDescription { get; }
        string Suggestion { get; }
        IList<Prize> Prizes { get; }
        void Complete(string answer);
    }

    public class Stage: IStage
    {
        public Stage(int order, IAssignment assignment, IList<Prize> prizes)
        {
            Order = order;
            Assignment = assignment;
            Prizes = prizes ?? new List<Prize>();
        }

        public int Order { get; }
        protected IAssignment Assignment { get; }
        public bool IsCompleted { get; protected set; }
        public bool IsSuccessful { get; protected set; }
        public string AssignmentDescription => Assignment?.Description;

        public string Suggestion => string.IsNullOrWhiteSpace(Assignment?.Suggestion)
            ? "Не сдавайся, подумай ещё!"
            : Assignment.Suggestion;

        public IList<Prize> Prizes { get; }

        public virtual void Complete(string answer)
        {
            IsSuccessful = Assignment.IsAnswerCorrect(answer);
            IsCompleted = true;
        }
    }
}
