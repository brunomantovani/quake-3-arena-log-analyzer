using Quake3ArenaLogAnalyzer.Common.Mediator;

namespace Quake3ArenaLogAnalyzer.Application.Commands.ClientConnected
{
    public sealed record ClientConnectCommand(int PlayerId) : ICommand;
}