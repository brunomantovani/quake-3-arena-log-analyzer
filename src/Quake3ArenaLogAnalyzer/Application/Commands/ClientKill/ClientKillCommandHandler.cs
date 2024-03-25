using Quake3ArenaLogAnalyzer.Application.Commands.Abstractions;
using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;
using Quake3ArenaLogAnalyzer.DomainServices.CurrentGameMatch;

namespace Quake3ArenaLogAnalyzer.Application.Commands.ClientKill
{
    public sealed class ClientKillCommandHandler(ICurrentGameMatchService currentGameMatchService)
        : CurrentGameMatchCommandHandlerTemplateMethod<ClientKillCommand>(currentGameMatchService)
    {
        protected override void Handle(GameMatch gameMatch, ClientKillCommand command)
        {
            gameMatch.AddKill(
                killerPlayerId: command.KillerId,
                victimPlayerId: command.VictimId,
                meansOfDeathId: command.MeansOfDeathId
            );
        }
    }
}
