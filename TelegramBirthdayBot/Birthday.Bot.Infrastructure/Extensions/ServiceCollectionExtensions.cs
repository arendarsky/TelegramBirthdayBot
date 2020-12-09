using Birthday.Bot.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Birthday.Bot.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStageRepository, StageRepository>();
        }
    }
}
