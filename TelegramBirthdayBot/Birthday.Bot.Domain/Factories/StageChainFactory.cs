using System.Collections.Generic;
using System.Linq;
using Birthday.Bot.Domain.DataInterfaces.Stage;
using Birthday.Bot.Domain.Entities.Stage;

namespace Birthday.Bot.Domain.Factories
{
    public class StageChainFactory: IEntityFactory<IEnumerable<IStageData>, IStageChain>
    {
        private readonly IEntityFactory<IStageData, IStage> _stageFactory;

        public StageChainFactory(IEntityFactory<IStageData, IStage> stageFactory)
        {
            _stageFactory = stageFactory;
        }

        public IStageChain Make(IEnumerable<IStageData> data)
        {
            return data.Aggregate<IStageData, IStageChain>(null,
                (current, stageData) => new StageChain(_stageFactory.Make(stageData), current));
        }
    }
}
