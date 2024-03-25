using Quake3ArenaLogAnalyzer.Application.Commands.ClientUserinfoChanged;
using Quake3ArenaLogAnalyzer.Infraestructure.Parsers;
using System.Text.RegularExpressions;

namespace Quake3ArenaLogAnalyzer.Tests.Infraestructure.Parsers
{

    [TestFixture]
    public partial class ClientUserinfoChangedCommandParserStrategyTests
    {
        [Test]
        public void ClientUserinfoChangedCommandParserStrategy_Trigger_Returns_Correct_Value()
        {
            // Arrange
            var strategy = new ClientUserinfoChangedCommandParserStrategy();

            // Act
            var trigger = strategy.Trigger;

            // Assert
            Assert.That(trigger, Is.EqualTo("ClientUserinfoChanged:"));
        }

        [Test]
        public void ClientUserinfoChangedCommandParserStrategy_Pattern_Is_Correct()
        {
            // Arrange
            var strategy = new ClientUserinfoChangedCommandParserStrategy();
            var expectedPattern = ClientUserinfoChangedRegex();

            // Act
            var pattern = strategy.Pattern;

            // Assert
            Assert.That(pattern.ToString(), Is.EqualTo(expectedPattern.ToString()));
        }

        [Test]
        public void ClientUserinfoChangedCommandParserStrategy_Parse_Returns_Null_When_Line_Does_Not_Match_Pattern()
        {
            // Arrange
            var strategy = new ClientUserinfoChangedCommandParserStrategy();
            var line = "PlayerConnected: 123";

            // Act
            var result = strategy.Parse(line);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ClientUserinfoChangedCommandParserStrategy_Parse_Returns_ClientUserinfoChangedCommand_When_Line_Matches_Pattern()
        {
            // Arrange
            var strategy = new ClientUserinfoChangedCommandParserStrategy();
            var line = "ClientUserinfoChanged: 1 n\\playerName";

            // Act
            var result = strategy.Parse(line);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ClientUserinfoChangedCommand>());
        }

        [Test]
        public void ClientUserinfoChangedCommandParserStrategy_Parse_Creates_Correct_ClientUserinfoChangedCommand_When_Line_Matches_Pattern()
        {
            // Arrange
            var strategy = new ClientUserinfoChangedCommandParserStrategy();
            var line = "ClientUserinfoChanged: 1 n\\playerName";

            // Act
            var result = strategy.Parse(line) as ClientUserinfoChangedCommand;

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(result!.PlayerId, Is.EqualTo(1));
                Assert.That(result.PlayerName, Is.EqualTo("playerName"));
            });
        }

        [GeneratedRegex(@"ClientUserinfoChanged: (?<PlayerId>\d+) n\\(?<PlayerName>[^\\]+)")]
        private static partial Regex ClientUserinfoChangedRegex();
    }

}
