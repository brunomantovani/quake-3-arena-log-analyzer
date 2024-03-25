using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;

namespace Quake3ArenaLogAnalyzer.Tests.DomainModels.GameMatches
{

    [TestFixture]
    public class GameMatchTests
    {
        [Test]
        public void GameMatch_AddPlayer_Adds_Player_To_Players_Collection()
        {
            // Arrange
            var gameMatch = new GameMatch();
            var playerId = 1;

            // Act
            gameMatch.AddPlayer(playerId);

            // Assert
            Assert.That(gameMatch.Players.Any(p => p.Id == playerId), Is.True);
        }

        [Test]
        public void GameMatch_RemovePlayer_Removes_Player_From_Players_Collection()
        {
            // Arrange
            var gameMatch = new GameMatch();
            var playerId = 1;
            gameMatch.AddPlayer(playerId);

            // Act
            gameMatch.RemovePlayer(playerId);

            // Assert
            Assert.That(gameMatch.Players.Any(p => p.Id == playerId), Is.False);
        }

        [Test]
        public void GameMatch_AddKill_Invokes_PlayerKilled_Event()
        {
            // Arrange
            var gameMatch = new GameMatch();
            var killerId = 1;
            var victimId = 2;
            var meansOfDeathId = 3;
            var eventInvoked = false;
            gameMatch.AddPlayer(killerId);
            gameMatch.AddPlayer(victimId);
            gameMatch.PlayerKilled += (e) => { eventInvoked = true; };

            // Act
            gameMatch.AddKill(killerId, victimId, meansOfDeathId);

            // Assert
            Assert.That(eventInvoked, Is.True);
        }

        [Test]
        public void GameMatch_ChangePlayerInfo_Changes_Player_Name()
        {
            // Arrange
            var gameMatch = new GameMatch();
            var playerId = 1;
            var originalName = "OriginalName";
            var newName = "NewName";
            gameMatch.AddPlayer(playerId);
            gameMatch.ChangePlayerInfo(playerId, originalName);

            // Act
            gameMatch.ChangePlayerInfo(playerId, newName);

            // Assert
            var player = gameMatch.Players.FirstOrDefault(p => p.Id == playerId);
            Assert.That(player?.Name, Is.EqualTo(newName));
        }

        [Test]
        public void GameMatch_PlayerAdded_Event_Is_Invoked()
        {
            // Arrange
            var gameMatch = new GameMatch();
            var eventInvoked = false;
            gameMatch.PlayerAdded += (e) => { eventInvoked = true; };

            // Act
            gameMatch.AddPlayer(1);

            // Assert
            Assert.That(eventInvoked, Is.True);
        }

        [Test]
        public void GameMatch_PlayerRemoved_Event_Is_Invoked()
        {
            // Arrange
            var gameMatch = new GameMatch();
            gameMatch.AddPlayer(1);
            var eventInvoked = false;
            gameMatch.PlayerRemoved += (e) => { eventInvoked = true; };

            // Act
            gameMatch.RemovePlayer(1);

            // Assert
            Assert.That(eventInvoked, Is.True);
        }

        [Test]
        public void GameMatch_PlayerInfoChanged_Event_Is_Invoked()
        {
            // Arrange
            var gameMatch = new GameMatch();
            gameMatch.AddPlayer(1);
            var eventInvoked = false;
            gameMatch.PlayerInfoChanged += (e) => { eventInvoked = true; };

            // Act
            gameMatch.ChangePlayerInfo(1, "NewName");

            // Assert
            Assert.That(eventInvoked, Is.True);
        }

        [Test]
        public void GameMatch_PlayerKilled_Event_Is_Invoked()
        {
            // Arrange
            var gameMatch = new GameMatch();
            gameMatch.AddPlayer(1);
            gameMatch.AddPlayer(2);
            var eventInvoked = false;
            gameMatch.PlayerKilled += (e) => { eventInvoked = true; };

            // Act
            gameMatch.AddKill(1, 2, 3);

            // Assert
            Assert.That(eventInvoked, Is.True);
        }
    }
}