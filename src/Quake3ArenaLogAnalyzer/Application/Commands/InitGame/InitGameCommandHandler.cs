using Quake3ArenaLogAnalyzer.Common.Mediator;
using Quake3ArenaLogAnalyzer.DomainServices.CurrentGameMatch;
using Quake3ArenaLogAnalyzer.DomainServices.GameMatchList;

namespace Quake3ArenaLogAnalyzer.Application.Commands.InitGame
{
    public sealed class InitGameCommandHandler(ICurrentGameMatchService currentGameMatchService, IGameMatchListService gameMatchListService)
        : ICommandHandler<InitGameCommand>
    {
        public void Handle(InitGameCommand command)
        {
            var gameMatch = currentGameMatchService
                .StartNewMatch();

            gameMatchListService
                .RegisterGameMatch(gameMatch);
        }
    }
}
