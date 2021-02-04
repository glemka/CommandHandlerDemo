using System.Threading;
using System.Threading.Tasks;

namespace CommandHandlerDemo
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command, CancellationToken token);
    }
}