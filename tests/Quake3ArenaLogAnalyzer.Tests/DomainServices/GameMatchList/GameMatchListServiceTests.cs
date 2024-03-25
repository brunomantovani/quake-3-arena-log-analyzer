using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;
using Quake3ArenaLogAnalyzer.DomainServices.GameMatchList;

namespace Quake3ArenaLogAnalyzer.Tests.DomainServices.GameMatchList
{
    [TestFixture]
    public class GameMatchListServiceTests
    {
        [Test]
        public void GetAllGameMatches_Returns_Empty_Collection_At_Initialization()
        {
            // Arrange
            var service = new GameMatchListService();

            // Act
            var matches = service.GetAllGameMatches();

            // Assert
            Assert.That(matches, Is.Empty);
        }

        [Test]
        public void RegisterGameMatch_Adds_GameMatch_To_List()
        {
            // Arrange
            var service = new GameMatchListService();
            var gameMatch = new GameMatch();

            // Act
            service.RegisterGameMatch(gameMatch);
            var matches = service.GetAllGameMatches().ToList();

            // Assert
            Assert.That(matches, Does.Contain(gameMatch));
        }

        [Test]
        public void RegisterGameMatch_Does_Not_Add_Duplicate_GameMatch()
        {
            // Arrange
            var service = new GameMatchListService();
            var gameMatch = new GameMatch();

            // Act
            service.RegisterGameMatch(gameMatch);
            service.RegisterGameMatch(gameMatch);
            var matches = service.GetAllGameMatches();

            // Assert
            Assert.That(matches.Count(), Is.EqualTo(1));
        }

        [Test]
        public void RegisterGameMatch_Throws_Exception_When_Null_GameMatch()
        {
            // Arrange
            var service = new GameMatchListService();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => service.RegisterGameMatch(null!));
        }
    }
}
