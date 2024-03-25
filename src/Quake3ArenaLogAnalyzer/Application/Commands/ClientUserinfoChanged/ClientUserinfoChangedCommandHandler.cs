using Quake3ArenaLogAnalyzer.Application.Commands.Abstractions;
using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;
using Quake3ArenaLogAnalyzer.DomainServices.CurrentGameMatch;

namespace Quake3ArenaLogAnalyzer.Application.Commands.ClientUserinfoChanged
{
    public sealed class ClientUserinfoChangedCommandHandler(ICurrentGameMatchService currentGameMatchService)
        : CurrentGameMatchCommandHandlerTemplateMethod<ClientUserinfoChangedCommand>(currentGameMatchService)
    {
        protected override void Handle(GameMatch gameMatch, ClientUserinfoChangedCommand command)
        {
            gameMatch.ChangePlayerInfo(command.PlayerId, command.PlayerName);
        }
    }
}
