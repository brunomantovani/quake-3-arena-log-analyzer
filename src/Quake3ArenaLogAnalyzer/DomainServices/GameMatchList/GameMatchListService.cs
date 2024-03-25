using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;

namespace Quake3ArenaLogAnalyzer.DomainServices.GameMatchList
{
    public sealed class GameMatchListService
        : IGameMatchListService
    {
        public HashSet<GameMatch> _gameMatches = [];

        public IEnumerable<GameMatch> GetAllGameMatches()
        {
            return _gameMatches.AsEnumerable();
        }

        public void RegisterGameMatch(GameMatch gameMatch)
        {
            ArgumentNullException.ThrowIfNull(gameMatch);

            if (_gameMatches.Contains(gameMatch))
            {
                return;
            }

            _gameMatches.Add(gameMatch);
        }
    }
}
