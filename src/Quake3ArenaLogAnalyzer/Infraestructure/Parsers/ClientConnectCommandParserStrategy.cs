using Quake3ArenaLogAnalyzer.Application.Commands.ClientConnected;
using Quake3ArenaLogAnalyzer.Infraestructure.Parsers.Abstractions;
using System.Text.RegularExpressions;

namespace Quake3ArenaLogAnalyzer.Infraestructure.Parsers
{
    public sealed class ClientConnectCommandParserStrategy
        : BaseCommandParserStrategy<ClientConnectCommand>
    {
        public override string Trigger => "ClientConnect:";
        public override Regex Pattern => new($@"{Trigger} (?<PlayerId>\d+)");

        protected override ClientConnectCommand FromMatchGroups(GroupCollection groups)
        {
            var playerId = int.Parse(groups["PlayerId"].Value);
            return new ClientConnectCommand(playerId);
        }
    }
}
