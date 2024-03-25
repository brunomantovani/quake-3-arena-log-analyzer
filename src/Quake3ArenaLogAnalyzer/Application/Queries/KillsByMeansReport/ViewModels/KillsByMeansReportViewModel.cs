using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;

namespace Quake3ArenaLogAnalyzer.Application.Queries.KillsByMeansReport.ViewModels
{
    public sealed class KillsByMeansReportViewModel
        : Dictionary<string, KillsByMeansViewModel>
    {
        public static KillsByMeansReportViewModel FromGameMatches(IEnumerable<GameMatch> matches)
        {
            var output = new KillsByMeansReportViewModel();

            foreach (var item in matches.Select((match, index) => new { Match = match, Index = index }))
            {
                output.Add($"game-{item.Index + 1}", new KillsByMeansViewModel(item.Match));
            }

            return output;
        }
    }
}
