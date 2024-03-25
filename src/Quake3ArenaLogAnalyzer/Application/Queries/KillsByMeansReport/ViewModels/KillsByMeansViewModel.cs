using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;

namespace Quake3ArenaLogAnalyzer.Application.Queries.KillsByMeansReport.ViewModels
{
    public sealed class KillsByMeansViewModel(GameMatch gameMatch)
    {
        public IDictionary<string, int> KillsByMeans { get; } = gameMatch.KillsByMeansScoreboard.OrderedBoard;
    }
}
