using Quake3ArenaLogAnalyzer.Application.Commands.Abstractions;
using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;
using Quake3ArenaLogAnalyzer.DomainServices.CurrentGameMatch;

namespace Quake3ArenaLogAnalyzer.Application.Commands.ClientConnected
{
    public sealed class ClientConnectCommandHandler(ICurrentGameMatchService currentGameMatchService)
        : CurrentGameMatchCommandHandlerTemplateMethod<ClientConnectCommand>(currentGameMatchService)
    {
        protected override void Handle(GameMatch gameMatch, ClientConnectCommand command)
        {
            gameMatch.AddPlayer(command.PlayerId);
        }
    }
}