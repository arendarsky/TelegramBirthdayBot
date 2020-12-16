using System;
using System.Collections.Generic;
using System.Text;
using Birthday.Bot.Domain.DataInterfaces.Stage;

namespace Birthday.Bot.Infrastructure
{
    public interface IDataContext
    {
        IEnumerable<IStageData> Stages { get; }
        void SaveChanges();
    }
}
