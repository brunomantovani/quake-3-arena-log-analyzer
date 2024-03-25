using Microsoft.Extensions.DependencyInjection;

namespace Quake3ArenaLogAnalyzer.Common.Mediator
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(
            this IServiceCollection services)
        {
            return services.AddSingleton<IMediator, Internal.Mediator>();
        }
    }
}
