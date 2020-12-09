using System;
using System.Collections.Generic;
using System.Text;
using Birthday.Bot.Domain.DataInterfaces.Assignment;
using Birthday.Bot.Domain.Entities.Assignment;

namespace Birthday.Bot.Domain.Factories
{
    public class AssignmentFactory: IEntityFactory<IAssignmentData, IAssignment>
    {
        public IAssignment Make(IAssignmentData data)
        {
            return new Assignment(data.Description, data.CorrectAnswers);
        }
    }
}
