using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Birthday.Bot.Domain.DataInterfaces.Stage;
using Birthday.Bot.Domain.Entities.Stage;

namespace Birthday.Bot.Domain.Factories
{
    public class StageChainFactory: IEntityFactory<IStageChainData, IStageChain>
    {
        private readonly IEntityFactory<IStageData, IStage> _stageFactory;

        public StageChainFactory(IEntityFactory<IStageData, IStage> stageFactory)
        {
            _stageFactory = stageFactory;
        }

        public IStageChain Make(IStageChainData data)
        {
            return data.Stages.Aggregate<IStageData, IStageChain>(null,
                (current, stageData) => new StageChain(_stageFactory.Make(stageData), current));
        }
    }
}
