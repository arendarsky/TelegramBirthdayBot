using System.Collections;
using System.Collections.Generic;
using Birthday.Bot.Domain.DataInterfaces.Assignment;
using Birthday.Bot.Domain.DataInterfaces.Stage;
using Birthday.Bot.Domain.Entities;
using Newtonsoft.Json;

namespace Birthday.Bot.Infrastructure.DataModels
{
    public class StageData: IStageData
    {
        public int Order { get; set; }

        [JsonIgnore]
        public IAssignmentData Assignment
        {
            get => AssignmentImpl;
            set => AssignmentImpl = (AssignmentData) value;
        }

        [JsonProperty("Assignment")]
        public AssignmentData AssignmentImpl { get; set; }

        public IList<Prize> Prizes { get; set; }

    }
}
