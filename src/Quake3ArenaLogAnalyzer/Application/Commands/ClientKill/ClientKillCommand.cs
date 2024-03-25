using Quake3ArenaLogAnalyzer.Common.Mediator;

namespace Quake3ArenaLogAnalyzer.Application.Commands.ClientKill
{
    public sealed record ClientKillCommand(int KillerId, int VictimId, int MeansOfDeathId) : ICommand;
}