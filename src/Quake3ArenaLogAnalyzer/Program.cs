using Microsoft.Extensions.DependencyInjection;
using Quake3ArenaLogAnalyzer.Application.Queries.GameMatchList;
using Quake3ArenaLogAnalyzer.Application.Queries.KillsByMeansReport;
using Quake3ArenaLogAnalyzer.Application.Queries.PlayerRankingReport;
using Quake3ArenaLogAnalyzer.Infraestructure.IoC;
using Quake3ArenaLogAnalyzer.Infraestructure.Log;
using Quake3ArenaLogAnalyzer.Infraestructure.Printer;

namespace Quake3ArenaLogAnalyzer
{
    internal class Program
    {
        private static readonly ServiceProvider _serviceProvider = Container.CreateServiceProvider();
        private static readonly ConsolePrinterStrategy _printerStrategy = _serviceProvider.GetRequiredService<ConsolePrinterStrategy>();


        static void Main()
        {
            ReadLogToEnd("qgames.log");
            GameMatchListPrint();
            PlayerRankingReportPrint();
            KillsByMeansReportPrint();
        }

        private static void ReadLogToEnd(string filePath)
        {
            var logReader = _serviceProvider
                .GetRequiredService<ILogReader>();

            logReader.ReadToEnd(filePath);
        }

        private static void GameMatchListPrint()
        {
            var gameMatchList = _serviceProvider
                .GetRequiredService<GameMatchListQueryHandler>()
                .Handle();

            _printerStrategy.Print(
                title: "Game Match List",
                body: gameMatchList
            );
        }

        private static void KillsByMeansReportPrint()
        {
            var report = _serviceProvider
                .GetRequiredService<KillsByMeansReportQueryHandler>()
                .Handle();

            _printerStrategy.Print(
                title: "Kills By Means Report",
                body: report
            );
        }

        private static void PlayerRankingReportPrint()
        {
            var report = _serviceProvider
                .GetRequiredService<PlayerRankingReportQueryHandler>()
                .Handle();

            _printerStrategy.Print(
                title: "Player Ranking Report",
                body: report
            );
        }
    }
}
