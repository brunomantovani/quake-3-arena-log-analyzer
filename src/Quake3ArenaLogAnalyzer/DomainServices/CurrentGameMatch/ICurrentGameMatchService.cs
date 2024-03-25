using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;

namespace Quake3ArenaLogAnalyzer.DomainServices.CurrentGameMatch
{
    public interface ICurrentGameMatchService
    {
        GameMatch StartNewMatch();
        GameMatch GetCurrentMatch();
    }
}
