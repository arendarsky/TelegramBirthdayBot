using System;
using System.Collections.Generic;
using System.Text;
using Birthday.Bot.Domain.DataInterfaces.Assignment;
using Birthday.Bot.Domain.Entities.Assignment;

namespace Birthday.Bot.Infrastructure.DataModels
{
    public class AssignmentData: IAssignmentData
    {
        public string Description { get; set; }
        public string Suggestion { get; set; }
        public IEnumerable<string> CorrectAnswers { get; set; }
    }
}
