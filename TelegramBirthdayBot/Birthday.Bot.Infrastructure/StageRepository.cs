using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Birthday.Bot.Domain.DataInterfaces.Stage;
using Birthday.Bot.Services.Interfaces;

namespace Birthday.Bot.Infrastructure
{
    public class StageRepository: IStageRepository
    {
        private readonly IDataContext _context;

        public StageRepository(IDataContext context)
        {
            _context = context;
        }

        public IStageData FirstOrDefault(Func<IStageData, bool> expression)
        {
            return _context.Stages.FirstOrDefault(expression);
        }

        public IEnumerable<IStageData> GetAll()
        {
            return _context.Stages.OrderByDescending(stage => stage.Order);
        }

        public void ClearPrizes()
        {
            foreach (var stage in _context.Stages)
            {
                stage.Prizes.Clear();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
