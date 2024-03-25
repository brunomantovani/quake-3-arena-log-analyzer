using Quake3ArenaLogAnalyzer.Application.Queries.KillsByMeansReport.ViewModels;
using Quake3ArenaLogAnalyzer.DomainServices.GameMatchList;

namespace Quake3ArenaLogAnalyzer.Application.Queries.KillsByMeansReport
{
    public sealed class KillsByMeansReportQueryHandler(IGameMatchListService gameMatchListService)
    {
        public KillsByMeansReportViewModel Handle()
        {
            var matches = gameMatchListService
                .GetAllGameMatches();

            return KillsByMeansReportViewModel
                .FromGameMatches(matches);
        }
    }
}
