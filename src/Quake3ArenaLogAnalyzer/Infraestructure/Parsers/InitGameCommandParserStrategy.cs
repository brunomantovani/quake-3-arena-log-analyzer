using Quake3ArenaLogAnalyzer.Application.Commands.InitGame;
using Quake3ArenaLogAnalyzer.Common.Mediator;
using Quake3ArenaLogAnalyzer.Infraestructure.Parsers.Abstractions;
using System.Text.RegularExpressions;

namespace Quake3ArenaLogAnalyzer.Infraestructure.Parsers
{
    public sealed class InitGameCommandParserStrategy
        : ICommandParserStrategy
    {
        public string Trigger => "InitGame:";
        public Regex Pattern => new($@"{Trigger}");

        public ICommand? Parse(string line)
        {
            var match = CreateMatch(line);

            if (match.Success)
            {
                return new InitGameCommand();
            }

            return null;
        }

        private Match CreateMatch(string line)
        {
            return Pattern.Match(line);
        }
    }
}
