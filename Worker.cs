using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommandHandlerDemo.Commands;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CommandHandlerDemo
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public ICommandHandler<CreateUserCommand> handler { get; set; }

        public Worker(ILogger<Worker> logger, ICommandHandler<CreateUserCommand> handler)
        {
            this.handler = handler;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await handler.Handle(new CreateUserCommand(), stoppingToken);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
