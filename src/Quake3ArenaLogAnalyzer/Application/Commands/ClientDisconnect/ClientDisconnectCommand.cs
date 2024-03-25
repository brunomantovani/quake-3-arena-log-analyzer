using Quake3ArenaLogAnalyzer.Common.Mediator;

namespace Quake3ArenaLogAnalyzer.Application.Commands.ClientDisconnect
{
    public sealed record ClientDisconnectCommand(int PlayerId) : ICommand;
}