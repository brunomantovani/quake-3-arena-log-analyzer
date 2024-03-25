using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;

namespace Quake3ArenaLogAnalyzer.Application.Queries.PlayerRankingReport.ViewModels
{
    public sealed class PlayerRankingReportViewModel(
        IEnumerable<GameMatch> matches)
    {
        public PlayerRankingViewModel PlayerRanking { get; } = PlayerRankingViewModel.FromGameMatches(matches);

        public static PlayerRankingReportViewModel FromGameMatches(IEnumerable<GameMatch> matches)
        {
            return new PlayerRankingReportViewModel(matches);
        }
    }
}
