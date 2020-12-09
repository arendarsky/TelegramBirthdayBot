using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Birthday.Bot.Domain.DataInterfaces.Stage;
using Birthday.Bot.Domain.Entities.Stage;
using Birthday.Bot.Domain.Factories;
using Birthday.Bot.Services.Interfaces;
using Birthday.Bot.Services.Models;

namespace Birthday.Bot.Services.Services
{
    public interface IStageChainService
    {
        IStageChain CreateNew();
    }

    public class StageChainService: IStageChainService
    {
        private readonly IStageRepository _stageRepository;
        private readonly IEntityFactory<IEnumerable<IStageData>, IStageChain> _stageChainFactory;

        public StageChainService(IStageRepository stageRepository, IEntityFactory<IEnumerable<IStageData>, IStageChain> stageChainFactory)
        {
            _stageRepository = stageRepository;
            _stageChainFactory = stageChainFactory;
        }

        public IStageChain CreateNew()
        {
            var stagesData = _stageRepository.GetAll();
            var stageChain = _stageChainFactory.Make(stagesData);
            return stageChain;
        }
    }
}
