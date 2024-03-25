using Quake3ArenaLogAnalyzer.Application.Queries.GameMatchList.ViewModels;
using Quake3ArenaLogAnalyzer.DomainServices.GameMatchList;

namespace Quake3ArenaLogAnalyzer.Application.Queries.GameMatchList
{
    public sealed class GameMatchListQueryHandler(IGameMatchListService gameMatchListService)
    {
        public GameMatchListViewModel Handle()
        {
            var matches = gameMatchListService
                .GetAllGameMatches();

            return GameMatchListViewModel
                .FromGameMatches(matches);
        }
    }
}
