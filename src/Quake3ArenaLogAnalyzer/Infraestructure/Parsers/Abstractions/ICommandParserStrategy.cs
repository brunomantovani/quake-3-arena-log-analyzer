using Quake3ArenaLogAnalyzer.Common.Mediator;

namespace Quake3ArenaLogAnalyzer.Infraestructure.Parsers.Abstractions
{
    public interface ICommandParserStrategy
    {
        string Trigger { get; }
        ICommand? Parse(string line);
    }
}
