using Quake3ArenaLogAnalyzer.Common.Mediator;

namespace Quake3ArenaLogAnalyzer.Application.Commands.ClientUserinfoChanged
{
    public sealed record ClientUserinfoChangedCommand(int PlayerId, string PlayerName) : ICommand;
}