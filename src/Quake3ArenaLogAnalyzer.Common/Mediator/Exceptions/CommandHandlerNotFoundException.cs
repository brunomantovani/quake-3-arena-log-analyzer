namespace Quake3ArenaLogAnalyzer.Common.Mediator.Exceptions
{
    public class CommandHandlerNotFoundException : Exception
    {
        public CommandHandlerNotFoundException() { }
        public CommandHandlerNotFoundException(string message) : base(message) { }
        public CommandHandlerNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
