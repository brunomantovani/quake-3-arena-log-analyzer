using Quake3ArenaLogAnalyzer.Common.Mediator;
using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;
using Quake3ArenaLogAnalyzer.DomainServices.CurrentGameMatch;

namespace Quake3ArenaLogAnalyzer.Application.Commands.Abstractions
{
    public abstract class CurrentGameMatchCommandHandlerTemplateMethod<TCommand>(
        ICurrentGameMatchService currentGameMatchService)
        : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        public void Handle(TCommand command)
        {
            var current = currentGameMatchService.GetCurrentMatch();
            Handle(current, command);
        }

        protected abstract void Handle(GameMatch gameMatch, TCommand command);
    }
}
