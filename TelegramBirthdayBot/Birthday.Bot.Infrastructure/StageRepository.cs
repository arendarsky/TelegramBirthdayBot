using System;
using System.Collections.Generic;
using Birthday.Bot.Domain.DataInterfaces.Stage;
using Birthday.Bot.Services.Interfaces;

namespace Birthday.Bot.Infrastructure
{
    public class StageRepository: IStageRepository
    {
        private readonly MemoryContext _context;

        public StageRepository(MemoryContext context)
        {
            _context = context;
        }

        public IEnumerable<IStageData> GetAll()
        {
            return _context.Stages;
        }
    }
}
