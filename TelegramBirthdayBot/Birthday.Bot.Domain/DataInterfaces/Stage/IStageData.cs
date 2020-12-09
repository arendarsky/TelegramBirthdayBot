using Birthday.Bot.Domain.DataInterfaces.Assignment;

namespace Birthday.Bot.Domain.DataInterfaces.Stage
{
    public interface IStageData
    {
        int Order { get; set; }
        IAssignmentData Assignment { get; set; }
    }
}
