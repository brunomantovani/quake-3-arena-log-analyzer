namespace Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Events
{
    public sealed record PlayerInfoChangedEvent(int PlayerId, string PlayerName);
}
