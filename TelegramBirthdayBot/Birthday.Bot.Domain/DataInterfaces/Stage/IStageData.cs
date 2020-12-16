using System.Collections.Generic;
using Birthday.Bot.Domain.DataInterfaces.Assignment;
using Birthday.Bot.Domain.Entities;

namespace Birthday.Bot.Domain.DataInterfaces.Stage
{
    public interface IStageData
    {
        int Order { get; set; }
        IAssignmentData Assignment { get; set; }
        IList<Prize> Prizes { get; set; }
    }
}
