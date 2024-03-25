namespace Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Scoreboards
{
    public sealed class TotalKillsScoreboard
    {
        public int TotalKills { get; private set; }

        public TotalKillsScoreboard(GameMatch gameMatch)
        {
            gameMatch.PlayerKilled += GameMatch_UpdateCounter;
        }

        private void GameMatch_UpdateCounter(Events.PlayerKilledEvent @event)
        {
            TotalKills++;
        }
    }
}
