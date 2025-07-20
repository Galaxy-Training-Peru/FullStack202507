
namespace NewBackgroundOptions
{
    public class NewHostedService : IHostedLifecycleService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Start NewHostedService");
            return Task.CompletedTask;
        }

        public Task StartedAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Started NewHostedService");
            return Task.CompletedTask; 
        }

        public Task StartingAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Starting NewHostedService");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stop NewHostedService");
            return Task.CompletedTask;
        }

        public Task StoppedAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stopped NewHostedService");
            return Task.CompletedTask;
        }

        public Task StoppingAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stopping NewHostedService");
            return Task.CompletedTask;
        }
    }
}
