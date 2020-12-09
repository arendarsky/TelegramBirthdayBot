using System;
using System.Collections.Generic;
using System.Text;
using Birthday.Bot.Domain.DataInterfaces.Assignment;
using Birthday.Bot.Domain.DataInterfaces.Stage;
using Birthday.Bot.Domain.Entities.Assignment;
using Birthday.Bot.Domain.Entities.Stage;
using Birthday.Bot.Domain.Factories;
using Birthday.Bot.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Birthday.Bot.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFactories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IEntityFactory<IStageData, IStage>, StageFactory>();
            serviceCollection.AddSingleton<IEntityFactory<IAssignmentData, IAssignment>, AssignmentFactory>();
            serviceCollection.AddSingleton<IEntityFactory<IEnumerable<IStageData>, IStageChain>, StageChainFactory>();
        }

        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStageChainService, StageChainService>();
            serviceCollection.AddSingleton<IStateService, StateService>();
        }
    }
}
