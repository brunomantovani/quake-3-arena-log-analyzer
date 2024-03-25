namespace Quake3ArenaLogAnalyzer.DomainServices.CurrentGameMatch.Exceptions
{
    public class GameMatchNotStartedException : Exception
    {
        public GameMatchNotStartedException() { }
        public GameMatchNotStartedException(string message) : base(message) { }
        public GameMatchNotStartedException(string message, Exception inner) : base(message, inner) { }
    }
}
