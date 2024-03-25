using Quake3ArenaLogAnalyzer.Common;
using Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Events;
using Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Exceptions;
using Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Scoreboards;
using Quake3ArenaLogAnalyzer.DomainModels.Players;
using System.Collections.ObjectModel;

namespace Quake3ArenaLogAnalyzer.DomainModels.GameMatches
{
    public delegate void PlayerAddedEventHandler(PlayerAddedEvent @event);
    public delegate void PlayerRemovedEventHandler(PlayerRemovedEvent @event);
    public delegate void PlayerInfoChangedEventHandler(PlayerInfoChangedEvent @event);
    public delegate void PlayerKilledEventHandler(PlayerKilledEvent @event);

    public sealed class GameMatch
    {
        private readonly List<Player> _players = [];

        public event PlayerAddedEventHandler? PlayerAdded;
        public event PlayerRemovedEventHandler? PlayerRemoved;
        public event PlayerInfoChangedEventHandler? PlayerInfoChanged;
        public event PlayerKilledEventHandler? PlayerKilled;

        public KillsByPlayerScoreboard KillsByPlayerScoreboard { get; }
        public KillsByMeansScoreboard KillsByMeansScoreboard { get; }
        public TotalKillsScoreboard TotalKillsScoreboard { get; }

        public GameMatch()
        {
            KillsByPlayerScoreboard = new(this);
            KillsByMeansScoreboard = new(this);
            TotalKillsScoreboard = new(this);
        }

        public ReadOnlyCollection<Player> Players
        {
            get => _players.AsReadOnly();
        }

        public void AddPlayer(int playerId)
        {
            var player = new Player(playerId);
            AddPlayerIfNotExists(player);
        }

        public void RemovePlayer(int playerId)
        {
            var player = FindPlayer(playerId);
            _players.Remove(player);

            PlayerRemoved?.Invoke(new PlayerRemovedEvent(player));
        }

        public void AddKill(int killerPlayerId, int victimPlayerId, int meansOfDeathId)
        {
            var killer = FindPlayer(killerPlayerId);
            var victim = FindPlayer(victimPlayerId);
            var meansOfDeath = (MeansOfDeath)meansOfDeathId;

            PlayerKilled?.Invoke(new PlayerKilledEvent(killer, victim, meansOfDeath));
        }

        public void ChangePlayerInfo(int playerId, string playerName)
        {
            var player = FindPlayer(playerId);
            player.ChangeName(playerName);

            PlayerInfoChanged?.Invoke(new PlayerInfoChangedEvent(playerId, playerName));
        }

        private Player FindPlayer(int playerId)
        {
            if (playerId == Constants.PlayerWorldId)
            {
                return Player.PlayerWorld;
            }

            var player = _players
                .SingleOrDefault(x => x.Id.Equals(playerId));

            if (player is not null)
            {
                return player;
            }

            throw new PlayerNotFoundInGameMatchException(this, message: $"Not found player {playerId} in this game match");
        }

        private bool IsPlayerAlreadyAdded(Player player)
        {
            return _players.Contains(player);
        }

        private void AddPlayerIfNotExists(Player player)
        {
            if (player.IsPlayerWorld())
            {
                return;
            }

            if (IsPlayerAlreadyAdded(player))
            {
                return;
            }

            _players.Add(player);

            PlayerAdded?.Invoke(new PlayerAddedEvent(player));
        }
    }
}