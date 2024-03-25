using Microsoft.Extensions.DependencyInjection;
using Quake3ArenaLogAnalyzer.Common.Mediator;
using Quake3ArenaLogAnalyzer.Infraestructure.Parsers.Abstractions;

namespace Quake3ArenaLogAnalyzer.Infraestructure.Log
{
    public sealed class LogReader : ILogReader
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;
        private readonly IEnumerable<ICommandParserStrategy> _commandParsers;

        public LogReader(IServiceProvider serviceProvider, IMediator mediator)
        {
            _serviceProvider = serviceProvider;
            _mediator = mediator;
            _commandParsers = GetSupportedCommandParsers();
        }

        public void ReadToEnd(string filePath)
        {
            using var sr = new StreamReader(filePath);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                HandleCommand(line);
            }
        }

        private void HandleCommand(string line)
        {
            foreach (var supportedCommandType in _commandParsers)
            {
                if (ContainsTriggerInLine(supportedCommandType.Trigger, line))
                {
                    var command = supportedCommandType.Parse(line);

                    if (command != null)
                    {
                        _mediator.Send(command);
                    }
                }
            }
        }

        private IEnumerable<ICommandParserStrategy> GetSupportedCommandParsers()
        {
            return _serviceProvider.GetServices<ICommandParserStrategy>();
        }

        private static bool ContainsTriggerInLine(string trigger, string line)
        {
            return line.Contains(trigger, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}