using Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Scoreboards;
using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;
using Quake3ArenaLogAnalyzer.DomainModels.Players;

namespace Quake3ArenaLogAnalyzer.Tests.DomainModels.GameMatches.Scoreboards
{

    [TestFixture]
    public class TotalKillsScoreboardTests
    {
        [Test]
        public void TotalKillsScoreboard_TotalKills_Is_Zero_At_Initialization()
        {
            // Arrange
            var gameMatch = new GameMatch();

            // Act
            var scoreboard = new TotalKillsScoreboard(gameMatch);

            // Assert
            Assert.That(scoreboard.TotalKills, Is.Zero);
        }

        [Test]
        public void TotalKillsScoreboard_TotalKills_Increases_After_Adding_Kill()
        {
            // Arrange
            var gameMatch = new GameMatch();
            var scoreboard = new TotalKillsScoreboard(gameMatch);
            var initialKills = scoreboard.TotalKills;
            var player1 = new Player(1);
            var player2 = new Player(2);
            gameMatch.AddPlayer(player1.Id);
            gameMatch.AddPlayer(player2.Id);

            // Act
            gameMatch.AddKill(player1.Id, player2.Id, 0);

            // Assert
            Assert.That(scoreboard.TotalKills, Is.EqualTo(initialKills + 1));
        }
    }
}
