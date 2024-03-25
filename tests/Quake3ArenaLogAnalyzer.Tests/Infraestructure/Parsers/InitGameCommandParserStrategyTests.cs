using Quake3ArenaLogAnalyzer.Application.Commands.InitGame;
using Quake3ArenaLogAnalyzer.Infraestructure.Parsers;

namespace Quake3ArenaLogAnalyzer.Tests.Infraestructure.Parsers
{

    [TestFixture]
    public class InitGameCommandParserStrategyTests
    {
        [Test]
        public void InitGameCommandParserStrategy_Trigger_Returns_Correct_Value()
        {
            // Arrange
            var strategy = new InitGameCommandParserStrategy();

            // Act
            var trigger = strategy.Trigger;

            // Assert
            Assert.That(trigger, Is.EqualTo("InitGame:"));
        }

        [Test]
        public void InitGameCommandParserStrategy_Parse_Returns_Null_When_Line_Does_Not_Match_Pattern()
        {
            // Arrange
            var strategy = new InitGameCommandParserStrategy();
            var line = "PlayerConnected: 123";

            // Act
            var result = strategy.Parse(line);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void InitGameCommandParserStrategy_Parse_Returns_InitGameCommand_When_Line_Matches_Pattern()
        {
            // Arrange
            var strategy = new InitGameCommandParserStrategy();
            var line = "InitGame:";

            // Act
            var result = strategy.Parse(line);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<InitGameCommand>());
        }
    }
}