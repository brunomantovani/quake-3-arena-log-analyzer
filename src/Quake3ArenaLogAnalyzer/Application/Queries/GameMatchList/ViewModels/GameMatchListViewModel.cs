using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;

namespace Quake3ArenaLogAnalyzer.Application.Queries.GameMatchList.ViewModels
{
    public sealed class GameMatchListViewModel
        : Dictionary<string, GameMatchViewModel>
    {
        public static GameMatchListViewModel FromGameMatches(
            IEnumerable<GameMatch> matches)
        {
            var output = new GameMatchListViewModel();

            foreach (var item in matches.Select((match, index) => new { Match = match, Index = index }))
            {
                output.Add($"game_{item.Index + 1}", new GameMatchViewModel(item.Match));
            }

            return output;
        }
    }
}
