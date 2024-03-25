using Quake3ArenaLogAnalyzer.Common;
using Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Events;
using Quake3ArenaLogAnalyzer.DomainModels.Players;
using System.Collections.ObjectModel;

namespace Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Scoreboards
{
    public sealed class KillsByPlayerScoreboard
    {
        private readonly Dictionary<Player, int> _killsByPlayerList = [];

        public ReadOnlyDictionary<string, int> OrderedBoard
        {
            get => _killsByPlayerList
                .OrderByDescending(x => x.Value)
                .ToDictionary(item => item.Key.Name, item => item.Value)
                .AsReadOnly();
        }

        public KillsByPlayerScoreboard(GameMatch gameMatch)
        {
            gameMatch.PlayerAdded += GameMatch_AddPlayerToList;
            gameMatch.PlayerRemoved += GameMatch_RemovePlayerFromList;
            gameMatch.PlayerKilled += GameMatch_UpdateList;
        }

        private void GameMatch_RemovePlayerFromList(PlayerRemovedEvent @event)
        {
            _killsByPlayerList.Remove(@event.Player);
        }

        private void GameMatch_AddPlayerToList(PlayerAddedEvent @event)
        {
            _killsByPlayerList.Add(@event.Player, Constants.Zero);
        }

        private void GameMatch_UpdateList(PlayerKilledEvent @event)
        {
            if (@event.Killer.IsPlayerWorld())
            {
                _killsByPlayerList[@event.Victim]--;
            }
            else
            {
                _killsByPlayerList[@event.Killer]++;
            }
        }
    }
}
