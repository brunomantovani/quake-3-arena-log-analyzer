using Quake3ArenaLogAnalyzer.DomainModels.GameMatches;
using Quake3ArenaLogAnalyzer.DomainServices.CurrentGameMatch;
using Quake3ArenaLogAnalyzer.DomainServices.CurrentGameMatch.Exceptions;

namespace Quake3ArenaLogAnalyzer.Tests.DomainServices.CurrentGameMatch
{

    [TestFixture]
    public class CurrentGameMatchServiceTests
    {
        [Test]
        public void GetCurrentMatch_Throws_Exception_When_No_Match_Started()
        {
            // Arrange
            var service = new CurrentGameMatchService();

            // Act & Assert
            Assert.Throws<GameMatchNotStartedException>(() => service.GetCurrentMatch());
        }

        [Test]
        public void StartNewMatch_Returns_New_GameMatch_Instance()
        {
            // Arrange
            var service = new CurrentGameMatchService();

            // Act
            var match = service.StartNewMatch();

            // Assert
            Assert.That(match, Is.Not.Null);
            Assert.That(match, Is.InstanceOf<GameMatch>());
        }

        [Test]
        public void GetCurrentMatch_Returns_Started_Match()
        {
            // Arrange
            var service = new CurrentGameMatchService();
            service.StartNewMatch();

            // Act
            var match = service.GetCurrentMatch();

            // Assert
            Assert.That(match, Is.Not.Null);
            Assert.That(match, Is.InstanceOf<GameMatch>());
        }

        [Test]
        public void GetCurrentMatch_Returns_Same_Match_After_Start()
        {
            // Arrange
            var service = new CurrentGameMatchService();
            var firstMatch = service.StartNewMatch();

            // Act
            var secondMatch = service.GetCurrentMatch();

            // Assert
            Assert.That(secondMatch, Is.SameAs(firstMatch));
        }
    }
}
