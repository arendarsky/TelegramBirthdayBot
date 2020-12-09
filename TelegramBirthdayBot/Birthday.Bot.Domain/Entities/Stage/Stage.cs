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
        void Complete(string answer);
    }

    public class Stage: IStage
    {
        public Stage(int order, IAssignment assignment)
        {
            Order = order;
            Assignment = assignment;
        }

        public int Order { get; }
        protected IAssignment Assignment { get; }
        public bool IsCompleted { get; protected set; }
        public bool IsSuccessful { get; protected set; }
        public string AssignmentDescription => Assignment?.Description;

        public string Suggestion => string.IsNullOrWhiteSpace(Assignment?.Suggestion)
            ? "Не сдавайся, подумай ещё!"
            : Assignment.Suggestion;

        public virtual void Complete(string answer)
        {
            IsSuccessful = Assignment.IsAnswerCorrect(answer);
            IsCompleted = true;
        }
    }
}
