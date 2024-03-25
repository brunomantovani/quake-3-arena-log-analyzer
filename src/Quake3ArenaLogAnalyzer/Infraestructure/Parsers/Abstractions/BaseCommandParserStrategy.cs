using Quake3ArenaLogAnalyzer.Common.Mediator;
using System.Text.RegularExpressions;

namespace Quake3ArenaLogAnalyzer.Infraestructure.Parsers.Abstractions
{
    public abstract class BaseCommandParserStrategy<TCommand> : ICommandParserStrategy
        where TCommand : ICommand
    {
        public abstract string Trigger { get; }
        public abstract Regex Pattern { get; }

        public ICommand? Parse(string line)
        {
            var match = CreateMatch(line);

            if (match.Success)
            {
                return FromMatchGroups(match.Groups);
            }

            return null;
        }

        protected Match CreateMatch(string line)
        {
            return Pattern.Match(line);
        }

        protected abstract TCommand FromMatchGroups(GroupCollection groups);
    }
}
