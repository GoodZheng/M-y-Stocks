using peano.mystocks.log.library;

namespace GetStocksDataService
{
    public class Worker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                LogService.Info("Worker running at: {time}" + DateTimeOffset.Now);

                await Task.Delay(1000*10, stoppingToken);
            }
        }
    }
}
