using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CommandHandlerDemo.Commands
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger)
        {
            Logger = logger;
        }

        public ILogger<CreateUserCommandHandler> Logger { get; }

        public async Task Handle(CreateUserCommand command, CancellationToken token)
        {
            this.Logger.LogInformation("HandlingMessage");
           await Task.Delay(1000, token); 
        }
    }
}