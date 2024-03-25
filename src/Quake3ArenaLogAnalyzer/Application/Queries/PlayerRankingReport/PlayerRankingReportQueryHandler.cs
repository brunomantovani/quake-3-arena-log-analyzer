using Quake3ArenaLogAnalyzer.Application.Queries.PlayerRankingReport.ViewModels;
using Quake3ArenaLogAnalyzer.DomainServices.GameMatchList;

namespace Quake3ArenaLogAnalyzer.Application.Queries.PlayerRankingReport
{
    public sealed class PlayerRankingReportQueryHandler(IGameMatchListService gameMatchListService)
    {
        public PlayerRankingReportViewModel Handle()
        {
            var matches = gameMatchListService
                .GetAllGameMatches();

            return PlayerRankingReportViewModel
                .FromGameMatches(matches);
        }
    }
}
