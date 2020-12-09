using System.Collections.Generic;

namespace Birthday.Bot.Domain.DataInterfaces.Assignment
{
    public interface IChoiceAssignmentData: IAssignmentData
    {
        IEnumerable<string> Choices { get; set; }
    }
}
