using Birthday.Bot.Domain.DataInterfaces.Assignment;
using Birthday.Bot.Domain.DataInterfaces.Stage;
using Birthday.Bot.Domain.Entities.Assignment;
using Birthday.Bot.Domain.Entities.Stage;

namespace Birthday.Bot.Domain.Factories
{
    public class StageFactory: IEntityFactory<IStageData, IStage>
    {
        private readonly IEntityFactory<IAssignmentData, IAssignment> _assignmentFactory;

        public StageFactory(IEntityFactory<IAssignmentData, IAssignment> assignmentFactory)
        {
            _assignmentFactory = assignmentFactory;
        }

        public IStage Make(IStageData data)
        {
            var assignment = _assignmentFactory.Make(data.Assignment);
            return new Stage(data.Order, assignment, data.Prizes);
        }
    }
}
