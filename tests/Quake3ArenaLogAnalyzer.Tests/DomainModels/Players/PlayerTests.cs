using Quake3ArenaLogAnalyzer.DomainModels.Players;

namespace Quake3ArenaLogAnalyzer.Tests.DomainModels.Players
{

    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Player_Constructor_Sets_Id_Correctly()
        {
            // Arrange
            var playerId = 1;

            // Act
            var player = new Player(playerId);

            // Assert
            Assert.That(player.Id, Is.EqualTo(playerId));
        }

        [Test]
        public void Player_Constructor_Sets_Name_Correctly()
        {
            // Arrange
            var playerId = 1;

            // Act
            var player = new Player(playerId);

            // Assert
            Assert.That(player.Name, Is.EqualTo($"Player_{playerId}"));
        }

        [Test]
        public void Player_ToString_Returns_Correct_Format()
        {
            // Arrange
            var playerId = 1;
            var playerName = "TestName";
            var expectedString = $"{playerId}: {playerName}";
            var player = new Player(playerId);
            player.ChangeName(playerName);

            // Act
            var result = player.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expectedString));
        }

        [Test]
        public void Player_Equals_Returns_True_When_Comparing_Same_Player()
        {
            // Arrange
            var playerId = 1;
            var player1 = new Player(playerId);
            var player2 = new Player(playerId);

            // Act & Assert
            Assert.That(player1, Is.EqualTo(player2));
        }

        [Test]
        public void Player_Equals_Returns_False_When_Comparing_Different_Player()
        {
            // Arrange
            var player1 = new Player(1);
            var player2 = new Player(2);

            // Act & Assert
            Assert.That(player1, Is.Not.EqualTo(player2));
        }

        [Test]
        public void Player_GetHashCode_Returns_Same_Value_For_Same_Player()
        {
            // Arrange
            var playerId = 1;
            var player1 = new Player(playerId);
            var player2 = new Player(playerId);

            // Act & Assert
            Assert.That(player1.GetHashCode(), Is.EqualTo(player2.GetHashCode()));
        }

        [Test]
        public void Player_GetHashCode_Returns_Different_Value_For_Different_Player()
        {
            // Arrange
            var player1 = new Player(1);
            var player2 = new Player(2);

            // Act & Assert
            Assert.That(player1.GetHashCode(), Is.Not.EqualTo(player2.GetHashCode()));
        }

        [Test]
        public void Player_ChangeName_Changes_Player_Name()
        {
            // Arrange
            var playerName = "OriginalName";
            var newName = "NewName";
            var player = new Player(1);

            // Act
            player.ChangeName(playerName);
            player.ChangeName(newName);

            // Assert
            Assert.That(player.Name, Is.EqualTo(newName));
        }

        [Test]
        public void Player_IsPlayerWorld_Returns_True_For_PlayerWorld()
        {
            // Arrange
            var player = Player.PlayerWorld;

            // Act & Assert
            Assert.That(player.IsPlayerWorld(), Is.True);
        }
    }

}
