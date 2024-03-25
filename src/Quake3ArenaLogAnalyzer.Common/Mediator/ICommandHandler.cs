namespace Quake3ArenaLogAnalyzer.Common.Mediator
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
