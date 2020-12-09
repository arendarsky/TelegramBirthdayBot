using System.Collections.Generic;
using Birthday.Bot.Domain.DataInterfaces.Assignment;

namespace Birthday.Bot.Infrastructure.DataModels
{
    public class AssignmentData: IAssignmentData
    {
        public string Description { get; set; }
        public string Suggestion { get; set; }
        public IEnumerable<string> CorrectAnswers { get; set; }
    }
}
