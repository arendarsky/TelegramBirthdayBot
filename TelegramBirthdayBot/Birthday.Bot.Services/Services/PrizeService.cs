using System;
using System.Collections.Generic;
using System.Text;
using Birthday.Bot.Domain.Entities;
using Birthday.Bot.Services.Interfaces;

namespace Birthday.Bot.Services.Services
{
    public interface IPrizeService
    {
        void SetPrize(int order, Prize prize);
        void ClearPrizes();
    }

    public class PrizeService: IPrizeService
    {
        private readonly IStageRepository _stageRepository;

        public PrizeService(IStageRepository stageRepository)
        {
            _stageRepository = stageRepository;
        }

        public void SetPrize(int order, Prize prize)
        {
            var stage = _stageRepository.FirstOrDefault(st => st.Order == order);
            stage.Prizes.Add(prize);
            _stageRepository.Save();
        }

        public void ClearPrizes()
        {
            _stageRepository.ClearPrizes();
            _stageRepository.Save();
        }
    }
}
