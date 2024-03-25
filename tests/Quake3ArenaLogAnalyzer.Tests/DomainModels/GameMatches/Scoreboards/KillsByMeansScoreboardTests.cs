using Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Scoreboards;
using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;
using Quake3ArenaLogAnalyzer.DomainModels.Players;

namespace Quake3ArenaLogAnalyzer.Tests.DomainModels.GameMatches.Scoreboards
{
    [TestFixture]
    public class KillsByMeansScoreboardTests
    {
        [Test]
        public void KillsByMeansScoreboard_OrderedBoard_Is_Empty_At_Initialization()
        {
            // Arrange
            var gameMatch = new GameMatch();

            // Act
            var scoreboard = new KillsByMeansScoreboard(gameMatch);

            // Assert
            Assert.That(scoreboard.OrderedBoard, Is.Empty);
        }

        [Test]
        public void KillsByMeansScoreboard_OrderedBoard_Contains_MeansOfDeath_After_Adding_Kill()
        {
            // Arrange
            var gameMatch = new GameMatch();
            var scoreboard = new KillsByMeansScoreboard(gameMatch);
            var meansOfDeath = MeansOfDeath.MOD_BFG;
            var player1 = new Player(1);
            var player2 = new Player(2);
            gameMatch.AddPlayer(player1.Id);
            gameMatch.AddPlayer(player2.Id);
            gameMatch.AddKill(player1.Id, player2.Id, (int)meansOfDeath);

            // Act
            var result = scoreboard.OrderedBoard;

            // Assert
            Assert.That(result.ContainsKey(meansOfDeath.ToString()), Is.True);
        }

        [Test]
        public void KillsByMeansScoreboard_OrderedBoard_Updates_Correctly_After_Adding_Multiple_Kills()
        {
            // Arrange
            var gameMatch = new GameMatch();
            var scoreboard = new KillsByMeansScoreboard(gameMatch);
            var meansOfDeath1 = MeansOfDeath.MOD_ROCKET;
            var meansOfDeath2 = MeansOfDeath.MOD_ROCKET_SPLASH;
            var player1 = new Player(1);
            var player2 = new Player(2);
            var player3 = new Player(3);
            gameMatch.AddPlayer(player1.Id);
            gameMatch.AddPlayer(player2.Id);
            gameMatch.AddPlayer(player3.Id);
            gameMatch.AddKill(player1.Id, player2.Id, (int)meansOfDeath1);
            gameMatch.AddKill(player1.Id, player3.Id, (int)meansOfDeath2);

            // Act
            var result = scoreboard.OrderedBoard;

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(result[meansOfDeath1.ToString()], Is.EqualTo(1));
                Assert.That(result[meansOfDeath2.ToString()], Is.EqualTo(1));
            });
        }
    }
}