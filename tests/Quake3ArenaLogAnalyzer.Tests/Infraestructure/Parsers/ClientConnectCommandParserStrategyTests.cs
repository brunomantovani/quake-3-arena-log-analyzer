using Quake3ArenaLogAnalyzer.Application.Commands.ClientConnected;
using Quake3ArenaLogAnalyzer.Infraestructure.Parsers;
using System.Text.RegularExpressions;

namespace Quake3ArenaLogAnalyzer.Tests.Infraestructure.Parsers
{

    [TestFixture]
    public partial class ClientConnectCommandParserStrategyTests
    {
        [Test]
        public void ClientConnectCommandParserStrategy_Trigger_Returns_Correct_Value()
        {
            // Arrange
            var strategy = new ClientConnectCommandParserStrategy();

            // Act
            var trigger = strategy.Trigger;

            // Assert
            Assert.That(trigger, Is.EqualTo("ClientConnect:"));
        }

        [Test]
        public void ClientConnectCommandParserStrategy_Pattern_Is_Correct()
        {
            // Arrange
            var strategy = new ClientConnectCommandParserStrategy();
            var expectedPattern = ClientConnectRegex();

            // Act
            var pattern = strategy.Pattern;

            // Assert
            Assert.That(pattern.ToString(), Is.EqualTo(expectedPattern.ToString()));
        }

        [Test]
        public void ClientConnectCommandParserStrategy_Parse_Returns_Null_When_Line_Does_Not_Match_Pattern()
        {
            // Arrange
            var strategy = new ClientConnectCommandParserStrategy();
            var line = "PlayerDisconnected: 123";

            // Act
            var result = strategy.Parse(line);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ClientConnectCommandParserStrategy_Parse_Returns_ClientConnectCommand_When_Line_Matches_Pattern()
        {
            // Arrange
            var strategy = new ClientConnectCommandParserStrategy();
            var line = "ClientConnect: 123";

            // Act
            var result = strategy.Parse(line);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ClientConnectCommand>());
        }

        [Test]
        public void ClientConnectCommandParserStrategy_Parse_Creates_Correct_ClientConnectCommand_When_Line_Matches_Pattern()
        {
            // Arrange
            var strategy = new ClientConnectCommandParserStrategy();
            var line = "ClientConnect: 123";

            // Act
            var result = strategy.Parse(line) as ClientConnectCommand;

            // Assert
            Assert.That(result!.PlayerId, Is.EqualTo(123));
        }

        [GeneratedRegex(@"ClientConnect: (?<PlayerId>\d+)")]
        private static partial Regex ClientConnectRegex();
    }
}