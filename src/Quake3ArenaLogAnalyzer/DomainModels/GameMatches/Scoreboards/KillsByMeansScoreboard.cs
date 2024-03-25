using Quake3ArenaLogAnalyzer.Common;
using Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Events;
using System.Collections.ObjectModel;

namespace Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Scoreboards
{
    public sealed class KillsByMeansScoreboard
    {
        private readonly Dictionary<MeansOfDeath, int> _killsByMeansList = [];

        public ReadOnlyDictionary<string, int> OrderedBoard
        {
            get => _killsByMeansList
                .OrderByDescending(x => x.Value)
                .ToDictionary(item => item.Key.ToString(), item => item.Value)
                .AsReadOnly();
        }

        public KillsByMeansScoreboard(
            GameMatch gameMatch)
        {
            gameMatch.PlayerKilled += GameMatch_AddMeansOfKillToList;
        }

        private void GameMatch_AddMeansOfKillToList(PlayerKilledEvent @event)
        {
            AddKillMeansIfNotExists(@event.MeansOfDeath);
            UpdateList(@event.MeansOfDeath);
        }

        private void AddKillMeansIfNotExists(MeansOfDeath meansOfDeath)
        {
            if (_killsByMeansList.ContainsKey(meansOfDeath))
            {
                return;
            }

            _killsByMeansList.Add(meansOfDeath, Constants.Zero);
        }

        private void UpdateList(MeansOfDeath meansOfDeath)
        {
            _killsByMeansList[meansOfDeath]++;
        }
    }
}
