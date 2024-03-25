namespace Quake3ArenaLogAnalyzer.Common.Mediator
{
    public interface IMediator
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
