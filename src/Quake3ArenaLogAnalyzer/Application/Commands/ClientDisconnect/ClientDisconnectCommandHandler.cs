using Quake3ArenaLogAnalyzer.Application.Commands.Abstractions;
using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;
using Quake3ArenaLogAnalyzer.DomainServices.CurrentGameMatch;

namespace Quake3ArenaLogAnalyzer.Application.Commands.ClientDisconnect
{
    public sealed class ClientDisconnectCommandHandler(ICurrentGameMatchService currentGameMatchService)
        : CurrentGameMatchCommandHandlerTemplateMethod<ClientDisconnectCommand>(currentGameMatchService)
    {
        protected override void Handle(GameMatch gameMatch, ClientDisconnectCommand command)
        {
            gameMatch.RemovePlayer(command.PlayerId);
        }
    }
}
