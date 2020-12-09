using Birthday.Bot.Domain.DataInterfaces.Stage;
using Birthday.Bot.Domain.Entities.Assignment;
using Birthday.Bot.Domain.Enums;

namespace Birthday.Bot.Domain.Entities.Stage
{
    public interface IStage
    {
        int Order { get; }
        bool IsCompleted { get; }
        bool IsSuccessful { get; }
        string AssignmentDescription { get; }
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

        public virtual void Complete(string answer)
        {
            IsSuccessful = Assignment.IsAnswerCorrect(answer);
            IsCompleted = true;
        }
    }
}
