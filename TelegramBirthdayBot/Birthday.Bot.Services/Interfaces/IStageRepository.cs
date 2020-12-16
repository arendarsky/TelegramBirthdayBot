using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Birthday.Bot.Domain.DataInterfaces.Stage;

namespace Birthday.Bot.Services.Interfaces
{
    public interface IStageRepository
    {
        IStageData FirstOrDefault(Func<IStageData, bool> expression);
        IEnumerable<IStageData> GetAll();
        void ClearPrizes();
        void Save();
    }
}
