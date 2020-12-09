using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Birthday.Bot.Domain.DataInterfaces.Stage;
using Birthday.Bot.Domain.Entities.Stage;

namespace Birthday.Bot.Services.Interfaces
{
    public interface IStageRepository
    {
        IEnumerable<IStageData> GetAll();
    }
}
