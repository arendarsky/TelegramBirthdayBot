using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday.Bot.Domain.DataInterfaces.Stage
{
    public interface IStageChainData
    {
        IEnumerable<IStageData> Stages { get; set; }
    }
}
