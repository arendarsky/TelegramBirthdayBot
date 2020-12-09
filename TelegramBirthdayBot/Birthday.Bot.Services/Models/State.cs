using Birthday.Bot.Domain.Entities.Stage;

namespace Birthday.Bot.Services.Models
{
    public class State
    {
        public State(IStageChain stageChain)
        {
            StageChain = stageChain;
        }

        public IStageChain StageChain { get; }
        public static State Default => new State(null);
    }
}
