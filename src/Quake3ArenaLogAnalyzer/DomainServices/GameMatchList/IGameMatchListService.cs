using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;

namespace Quake3ArenaLogAnalyzer.DomainServices.GameMatchList
{
    public interface IGameMatchListService
    {
        void RegisterGameMatch(GameMatch gameMatch);
        IEnumerable<GameMatch> GetAllGameMatches();
    }
}
