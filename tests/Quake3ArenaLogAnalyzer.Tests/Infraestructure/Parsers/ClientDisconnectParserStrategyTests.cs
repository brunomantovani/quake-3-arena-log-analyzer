using Quake3ArenaLogAnalyzer.Application.Commands.ClientDisconnect;
using Quake3ArenaLogAnalyzer.Infraestructure.Parsers;
using System.Text.RegularExpressions;

namespace Quake3ArenaLogAnalyzer.Tests.Infraestructure.Parsers
{
    [TestFixture]
    public partial class ClientDisconnectParserStrategyTests
    {
        [Test]
        public void ClientDisconnectParserStrategy_Trigger_Returns_Correct_Value()
        {
            // Arrange
            var strategy = new ClientDisconnectParserStrategy();

            // Act
            var trigger = strategy.Trigger;

            // Assert
            Assert.That(trigger, Is.EqualTo("ClientDisconnect:"));
        }

        [Test]
        public void ClientDisconnectParserStrategy_Pattern_Is_Correct()
        {
            // Arrange
            var strategy = new ClientDisconnectParserStrategy();
            var expectedPattern = ClientDiconnectRegex();

            // Act
            var pattern = strategy.Pattern;

            // Assert
            Assert.That(pattern.ToString(), Is.EqualTo(expectedPattern.ToString()));
        }

        [Test]
        public void ClientDisconnectParserStrategy_Parse_Returns_Null_When_Line_Does_Not_Match_Pattern()
        {
            // Arrange
            var strategy = new ClientDisconnectParserStrategy();
            var line = "PlayerConnected: 123";

            // Act
            var result = strategy.Parse(line);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ClientDisconnectParserStrategy_Parse_Returns_ClientDisconnectCommand_When_Line_Matches_Pattern()
        {
            // Arrange
            var strategy = new ClientDisconnectParserStrategy();
            var line = "ClientDisconnect: 123";

            // Act
            var result = strategy.Parse(line);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ClientDisconnectCommand>());
        }

        [Test]
        public void ClientDisconnectParserStrategy_Parse_Creates_Correct_ClientDisconnectCommand_When_Line_Matches_Pattern()
        {
            // Arrange
            var strategy = new ClientDisconnectParserStrategy();
            var line = "ClientDisconnect: 123";

            // Act
            var result = strategy.Parse(line) as ClientDisconnectCommand;

            // Assert
            Assert.That(result!.PlayerId, Is.EqualTo(123));
        }

        [GeneratedRegex(@"ClientDisconnect: (?<PlayerId>\d+)")]
        private static partial Regex ClientDiconnectRegex();
    }
}
