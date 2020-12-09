using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday.Bot.Domain.Entities.Stage
{
    public interface IStageChain
    {
        IStage Stage { get; }
        IStageChain Next { get; }
    }

    public class StageChain: IStageChain
    {
        public StageChain(IStage stage, IStageChain next)
        {
            Stage = stage;
            Next = next;
        }

        public IStage Stage { get; }
        public IStageChain Next { get; }
    }
}
