namespace Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Exceptions
{

    [Serializable]
    public class PlayerNotFoundInGameMatchException : Exception
    {
        public PlayerNotFoundInGameMatchException(GameMatch gameMatch, string message) : base(message)
        {
            GameMatch = gameMatch;
        }
        public PlayerNotFoundInGameMatchException(GameMatch gameMatch, string message, Exception inner) : base(message, inner)
        {
            GameMatch = gameMatch;
        }

        public GameMatch GameMatch { get; }
    }
}