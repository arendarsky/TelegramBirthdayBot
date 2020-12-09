using Birthday.Bot.Domain.DataInterfaces.Assignment;
using Birthday.Bot.Domain.Entities.Assignment;
using Birthday.Bot.Domain.Entities.Stage;
using Birthday.Bot.Domain.Enums;

namespace Birthday.Bot.Domain.DataInterfaces.Stage
{
    public interface IStageData
    {
        int Order { get; set; }
        IAssignmentData Assignment { get; set; }
    }
}
