using Microsoft.Extensions.DependencyInjection;
using Quake3ArenaLogAnalyzer.Common.Mediator.Exceptions;

namespace Quake3ArenaLogAnalyzer.Common.Mediator.Internal
{
    internal sealed class Mediator(IServiceProvider serviceProvider)
        : IMediator
    {
        public void Send<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var commandHandlerType = typeof(ICommandHandler<>)
                .MakeGenericType(command.GetType());

            var handler = serviceProvider.GetRequiredService(commandHandlerType)
                ?? throw new CommandHandlerNotFoundException($"No command handler registered for command type {typeof(TCommand)}.");

            var method = handler.GetType()
                .GetMethod(nameof(ICommandHandler<ICommand>.Handle));

            method!.Invoke(handler, [command]);
        }
    }
}
