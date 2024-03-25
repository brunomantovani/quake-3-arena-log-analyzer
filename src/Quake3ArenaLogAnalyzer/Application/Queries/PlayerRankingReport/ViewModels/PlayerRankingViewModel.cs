using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;

namespace Quake3ArenaLogAnalyzer.Application.Queries.PlayerRankingReport.ViewModels
{
    public sealed class PlayerRankingViewModel
        : Dictionary<string, int>
    {
        public static PlayerRankingViewModel FromGameMatches(IEnumerable<GameMatch> matches)
        {
            var output = new PlayerRankingViewModel();

            var query = matches
                .SelectMany(x => x.KillsByPlayerScoreboard.OrderedBoard)
                .GroupBy(x => x.Key)
                .Select(group => new { group.Key, TotalKills = group.Sum(x => x.Value) })
                .OrderByDescending(x => x.TotalKills)
            ;

            foreach (var item in query)
            {
                output.Add(item.Key, item.TotalKills);
            }

            return output;
        }
    }
}
