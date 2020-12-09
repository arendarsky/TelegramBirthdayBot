using System.Collections.Generic;
using Birthday.Bot.Domain.DataInterfaces.Stage;

namespace Birthday.Bot.Services.Interfaces
{
    public interface IStageRepository
    {
        IEnumerable<IStageData> GetAll();
    }
}
