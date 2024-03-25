using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;

namespace Quake3ArenaLogAnalyzer.Application.Queries.GameMatchList.ViewModels
{
    public class GameMatchViewModel(GameMatch gameMatch)
    {
        public int TotalKills { get; } = gameMatch.TotalKillsScoreboard.TotalKills;
        public IEnumerable<string> Players { get; } = gameMatch.Players.Select(player => player.Name);
        public IDictionary<string, int> Kills { get; } = gameMatch.KillsByPlayerScoreboard.OrderedBoard;
        public IDictionary<string, int> KillsByMeans { get; } = gameMatch.KillsByMeansScoreboard.OrderedBoard;
    }
}
