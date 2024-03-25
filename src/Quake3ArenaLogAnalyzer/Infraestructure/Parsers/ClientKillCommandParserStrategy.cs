using Quake3ArenaLogAnalyzer.Application.Commands.ClientKill;
using Quake3ArenaLogAnalyzer.Infraestructure.Parsers.Abstractions;
using System.Text.RegularExpressions;

namespace Quake3ArenaLogAnalyzer.Infraestructure.Parsers
{
    public sealed class ClientKillCommandParserStrategy
        : BaseCommandParserStrategy<ClientKillCommand>
    {
        public override string Trigger => "Kill:";
        public override Regex Pattern => new($@"{Trigger} (?<KillerId>\d+) (?<VictimId>\d+) (?<MeansOfDeathId>\d+):");

        protected override ClientKillCommand FromMatchGroups(GroupCollection groups)
        {
            int killerId = int.Parse(groups["KillerId"].Value);
            int victimId = int.Parse(groups["VictimId"].Value);
            int meansOfDeathId = int.Parse(groups["MeansOfDeathId"].Value);

            return new ClientKillCommand(killerId, victimId, meansOfDeathId);
        }
    }
}
