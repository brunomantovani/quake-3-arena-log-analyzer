using Quake3ArenaLogAnalyzer.DomainModels.Players;

namespace Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Events
{
    public sealed record PlayerRemovedEvent(Player Player);
}
