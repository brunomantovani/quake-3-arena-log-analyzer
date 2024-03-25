using Quake3ArenaLogAnalyzer.Application.Commands.ClientDisconnect;
using Quake3ArenaLogAnalyzer.Infraestructure.Parsers.Abstractions;
using System.Text.RegularExpressions;

namespace Quake3ArenaLogAnalyzer.Infraestructure.Parsers
{
    public sealed class ClientDisconnectParserStrategy
        : BaseCommandParserStrategy<ClientDisconnectCommand>
    {
        public override string Trigger => "ClientDisconnect:";
        public override Regex Pattern => new($@"{Trigger} (?<PlayerId>\d+)");

        protected override ClientDisconnectCommand FromMatchGroups(GroupCollection groups)
        {
            var playerId = int.Parse(groups["PlayerId"].Value);
            return new ClientDisconnectCommand(playerId);
        }
    }
}
