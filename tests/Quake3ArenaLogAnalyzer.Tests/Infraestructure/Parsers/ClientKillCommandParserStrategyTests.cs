using Quake3ArenaLogAnalyzer.Application.Commands.ClientKill;
using Quake3ArenaLogAnalyzer.Infraestructure.Parsers;
using System.Text.RegularExpressions;

namespace Quake3ArenaLogAnalyzer.Tests.Infraestructure.Parsers
{

    [TestFixture]
    public partial class ClientKillCommandParserStrategyTests
    {
        [Test]
        public void ClientKillCommandParserStrategy_Trigger_Returns_Correct_Value()
        {
            // Arrange
            var strategy = new ClientKillCommandParserStrategy();

            // Act
            var trigger = strategy.Trigger;

            // Assert
            Assert.That(trigger, Is.EqualTo("Kill:"));
        }

        [Test]
        public void ClientKillCommandParserStrategy_Pattern_Is_Correct()
        {
            // Arrange
            var strategy = new ClientKillCommandParserStrategy();
            var expectedPattern = KillRegex();

            // Act
            var pattern = strategy.Pattern;

            // Assert
            Assert.That(pattern.ToString(), Is.EqualTo(expectedPattern.ToString()));
        }

        [Test]
        public void ClientKillCommandParserStrategy_Parse_Returns_Null_When_Line_Does_Not_Match_Pattern()
        {
            // Arrange
            var strategy = new ClientKillCommandParserStrategy();
            var line = "PlayerConnected: 123";

            // Act
            var result = strategy.Parse(line);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ClientKillCommandParserStrategy_Parse_Returns_ClientKillCommand_When_Line_Matches_Pattern()
        {
            // Arrange
            var strategy = new ClientKillCommandParserStrategy();
            var line = "Kill: 1 2 0:";

            // Act
            var result = strategy.Parse(line);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ClientKillCommand>());
        }

        [Test]
        public void ClientKillCommandParserStrategy_Parse_Creates_Correct_ClientKillCommand_When_Line_Matches_Pattern()
        {
            // Arrange
            var strategy = new ClientKillCommandParserStrategy();
            var line = "Kill: 1 2 0:";

            // Act
            var result = strategy.Parse(line) as ClientKillCommand;

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(result!.KillerId, Is.EqualTo(1));
                Assert.That(result.VictimId, Is.EqualTo(2));
                Assert.That(result.MeansOfDeathId, Is.EqualTo(0));
            });
        }

        [GeneratedRegex(@"Kill: (?<KillerId>\d+) (?<VictimId>\d+) (?<MeansOfDeathId>\d+):")]
        private static partial Regex KillRegex();
    }

}
