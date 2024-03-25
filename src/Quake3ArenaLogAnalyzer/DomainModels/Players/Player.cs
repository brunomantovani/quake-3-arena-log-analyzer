using Quake3ArenaLogAnalyzer.Common;
using Quake3ArenaLogAnalyzer.Common.Abstractions;

namespace Quake3ArenaLogAnalyzer.DomainModels.Players
{
    public sealed class Player
        : Equatable<Player>
    {
        public readonly static Player PlayerWorld = new(Constants.PlayerWorldId, Constants.PlayerWorldName);

        public Player(int id)
        {
            Id = id;
            Name = $"Player_{id}";
        }

        private Player(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; private set; }

        public override string ToString()
        {
            return $"{Id}: {Name}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }

        public bool IsPlayerWorld()
        {
            return Equals(PlayerWorld);
        }
    }
}
