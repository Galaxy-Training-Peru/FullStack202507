
namespace NewBackgroundOptions
{
    public class RegularBackgroundService : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Background service starting");
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Polling for new messages " + DateTime.Now.Ticks);
                await Task.Delay(1000);
            }
        }
    }
}
