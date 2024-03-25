using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;
using Quake3ArenaLogAnalyzer.DomainServices.CurrentGameMatch.Exceptions;

namespace Quake3ArenaLogAnalyzer.DomainServices.CurrentGameMatch
{
    public sealed class CurrentGameMatchService
        : ICurrentGameMatchService
    {
        private GameMatch? _currentGameMatch;

        public GameMatch GetCurrentMatch()
        {
            if (_currentGameMatch == null)
            {
                throw new GameMatchNotStartedException();
            }

            return _currentGameMatch;
        }

        public GameMatch StartNewMatch()
        {
            return _currentGameMatch = new GameMatch();
        }
    }
}
