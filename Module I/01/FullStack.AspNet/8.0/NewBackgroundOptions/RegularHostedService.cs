
namespace NewBackgroundOptions
{
    public class RegularHostedService : IHostedService
    {
        private readonly ILogger<RegularHostedService> _logger;

        public RegularHostedService(ILogger<RegularHostedService> logger)
        {
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //await Task.Delay(5000);

            Console.WriteLine("Hosted Service starting");
            _logger.LogInformation("RegularHostedService is starting");
            //return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Hosted Service stopping");
            _logger.LogInformation("RegularHostedService is stopping");
            return Task.CompletedTask;
        }
    }
}
