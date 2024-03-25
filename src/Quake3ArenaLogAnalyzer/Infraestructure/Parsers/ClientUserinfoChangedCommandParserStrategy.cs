using Quake3ArenaLogAnalyzer.Application.Commands.ClientUserinfoChanged;
using Quake3ArenaLogAnalyzer.Infraestructure.Parsers.Abstractions;
using System.Text.RegularExpressions;

namespace Quake3ArenaLogAnalyzer.Infraestructure.Parsers
{
    public sealed class ClientUserinfoChangedCommandParserStrategy
        : BaseCommandParserStrategy<ClientUserinfoChangedCommand>
    {
        public override string Trigger => "ClientUserinfoChanged:";
        public override Regex Pattern => new($@"{Trigger} (?<PlayerId>\d+) n\\(?<PlayerName>[^\\]+)");

        protected override ClientUserinfoChangedCommand FromMatchGroups(GroupCollection groups)
        {
            var playerId = int.Parse(groups["PlayerId"].Value);
            var playerName = groups["PlayerName"].Value;

            return new ClientUserinfoChangedCommand(playerId, playerName);
        }
    }
}
