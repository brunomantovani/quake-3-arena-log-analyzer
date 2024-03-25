using Quake3ArenaLogAnalyzer.DomainModels.GameMatches.Scoreboards;
using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;
using Quake3ArenaLogAnalyzer.DomainModels.Players;
using Quake3ArenaLogAnalyzer.Common;

namespace Quake3ArenaLogAnalyzer.Tests.DomainModels.GameMatches.Scoreboards
{

    [TestFixture]
    public class KillsByPlayerScoreboardTests
    {
        [Test]
        public void KillsByPlayerScoreboard_OrderedBoard_Is_Empty_At_Initialization()
        {
            // Arrange
            var gameMatch = new GameMatch();

            // Act
            var scoreboard = new KillsByPlayerScoreboard(gameMatch);

            // Assert
            Assert.That(scoreboard.OrderedBoard, Is.Empty);
        }

        [Test]
        public void KillsByPlayerScoreboard_OrderedBoard_Contains_Player_After_Adding_Kill()
        {
            // Arrange
            var gameMatch = new GameMatch();
            var scoreboard = new KillsByPlayerScoreboard(gameMatch);
            var player1 = new Player(1);
            var player2 = new Player(2);
            gameMatch.AddPlayer(player1.Id);
            gameMatch.AddPlayer(player2.Id);
            gameMatch.AddKill(player1.Id, player2.Id, 0);

            // Act
            var result = scoreboard.OrderedBoard;

            // Assert
            Assert.That(result.ContainsKey(player1.Name), Is.True);
        }

        [Test]
        public void KillsByPlayerScoreboard_OrderedBoard_Updates_Correctly_After_Adding_Multiple_Kills()
        {
            // Arrange
            var gameMatch = new GameMatch();
            var scoreboard = new KillsByPlayerScoreboard(gameMatch);
            var player1 = new Player(1);
            var player2 = new Player(2);
            var player3 = new Player(3);
            gameMatch.AddPlayer(player1.Id);
            gameMatch.AddPlayer(player2.Id);
            gameMatch.AddPlayer(player3.Id);
            gameMatch.AddKill(player1.Id, player2.Id, 1);
            gameMatch.AddKill(player2.Id, player3.Id, 1);
            gameMatch.AddKill(player3.Id, player1.Id, 1);

            // Act
            var result = scoreboard.OrderedBoard;

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(result[player1.Name], Is.EqualTo(1));
                Assert.That(result[player2.Name], Is.EqualTo(1));
                Assert.That(result[player3.Name], Is.EqualTo(1));
            });
        }

        [Test]
        public void KillsByPlayerScoreboard_OrderedBoard_Removes_Player_After_Removing_From_GameMatch()
        {
            // Arrange
            var gameMatch = new GameMatch();
            var scoreboard = new KillsByPlayerScoreboard(gameMatch);
            var player1 = new Player(1);
            gameMatch.AddPlayer(player1.Id);
            gameMatch.AddKill(player1.Id, Constants.PlayerWorldId, 0);

            // Act
            gameMatch.RemovePlayer(player1.Id);
            var result = scoreboard.OrderedBoard;

            // Assert
            Assert.That(result.ContainsKey(player1.Name), Is.False);
        }

        [Test]
        public void KillsByPlayerScoreboard_OrderedBoard_Decreases_Kills_When_Player_Is_Killed_By_World()
        {
            // Arrange
            var gameMatch = new GameMatch();
            var scoreboard = new KillsByPlayerScoreboard(gameMatch);
            var player1 = new Player(1);
            var player2 = new Player(2);
            gameMatch.AddPlayer(player1.Id);
            gameMatch.AddPlayer(player2.Id);
            gameMatch.AddKill(player1.Id, player2.Id, 0);
            var initialKills = scoreboard.OrderedBoard[player1.Name];

            // Act
            gameMatch.AddKill(Constants.PlayerWorldId, player1.Id, 1);

            // Assert
            Assert.That(scoreboard.OrderedBoard[player1.Name], Is.EqualTo(initialKills - 1));
        }

    }
}