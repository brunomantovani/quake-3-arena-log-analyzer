using Microsoft.Extensions.DependencyInjection;
using Quake3ArenaLogAnalyzer.Application.Commands.ClientConnected;
using Quake3ArenaLogAnalyzer.Application.Commands.ClientDisconnect;
using Quake3ArenaLogAnalyzer.Application.Commands.ClientKill;
using Quake3ArenaLogAnalyzer.Application.Commands.ClientUserinfoChanged;
using Quake3ArenaLogAnalyzer.Application.Commands.InitGame;
using Quake3ArenaLogAnalyzer.Application.Queries.GameMatchList;
using Quake3ArenaLogAnalyzer.Application.Queries.KillsByMeansReport;
using Quake3ArenaLogAnalyzer.Application.Queries.PlayerRankingReport;
using Quake3ArenaLogAnalyzer.Common.Mediator;
using Quake3ArenaLogAnalyzer.DomainServices.CurrentGameMatch;
using Quake3ArenaLogAnalyzer.DomainServices.GameMatchList;
using Quake3ArenaLogAnalyzer.Infraestructure.Log;
using Quake3ArenaLogAnalyzer.Infraestructure.Parsers;
using Quake3ArenaLogAnalyzer.Infraestructure.Parsers.Abstractions;
using Quake3ArenaLogAnalyzer.Infraestructure.Printer;

namespace Quake3ArenaLogAnalyzer.Infraestructure.IoC
{
    public static class Container
    {
        public static ServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            AddParserStrategies(services);
            AddLogReader(services);
            AddDomainServices(services);
            AddPrinterStrategies(services);
            AddMediator(services);
            AddQueries(services);
            AddCommands(services);

            return services.BuildServiceProvider();
        }

        private static void AddLogReader(ServiceCollection services)
        {
            services.AddSingleton<ILogReader, LogReader>();
        }

        private static void AddDomainServices(ServiceCollection services)
        {
            services.AddSingleton<ICurrentGameMatchService, CurrentGameMatchService>();
            services.AddSingleton<IGameMatchListService, GameMatchListService>();
        }

        private static void AddPrinterStrategies(ServiceCollection services)
        {
            services.AddSingleton<ConsolePrinterStrategy>();
        }

        private static void AddMediator(ServiceCollection services)
        {
            services.AddMediator();            
        }

        private static void AddCommands(ServiceCollection services)
        {
            services.AddSingleton<ICommandHandler<InitGameCommand>, InitGameCommandHandler>();
            services.AddSingleton<ICommandHandler<ClientConnectCommand>, ClientConnectCommandHandler>();
            services.AddSingleton<ICommandHandler<ClientDisconnectCommand>, ClientDisconnectCommandHandler>();
            services.AddSingleton<ICommandHandler<ClientKillCommand>, ClientKillCommandHandler>();
            services.AddSingleton<ICommandHandler<ClientUserinfoChangedCommand>, ClientUserinfoChangedCommandHandler>();
        }

        private static void AddQueries(ServiceCollection services)
        {
            services.AddSingleton<GameMatchListQueryHandler>();
            services.AddSingleton<KillsByMeansReportQueryHandler>();
            services.AddSingleton<PlayerRankingReportQueryHandler>();
        }

        private static void AddParserStrategies(ServiceCollection services)
        {
            services.AddSingleton<ICommandParserStrategy, InitGameCommandParserStrategy>();
            services.AddSingleton<ICommandParserStrategy, ClientConnectCommandParserStrategy>();
            services.AddSingleton<ICommandParserStrategy, ClientDisconnectParserStrategy>();
            services.AddSingleton<ICommandParserStrategy, ClientKillCommandParserStrategy>();
            services.AddSingleton<ICommandParserStrategy, ClientUserinfoChangedCommandParserStrategy>();
        }
    }
}
