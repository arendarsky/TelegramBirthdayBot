using System;
using System.Collections.Generic;
using System.Text;
using Birthday.Bot.Domain.DataInterfaces.Assignment;
using Birthday.Bot.Domain.DataInterfaces.Stage;

namespace Birthday.Bot.Infrastructure.DataModels
{
    public class StageData: IStageData
    {
        public int Order { get; set; }
        public IAssignmentData Assignment { get; set; }
    }
}
