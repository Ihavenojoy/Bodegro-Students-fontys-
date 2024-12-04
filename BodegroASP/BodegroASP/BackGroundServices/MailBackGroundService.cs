using BodegroASP.BackGroundServices.MailTask;
namespace BodegroASP.BackGroundServices
{
    public class MailBackGroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MailBackGroundService> _logger;

        public MailBackGroundService(IServiceProvider serviceProvider, ILogger<MailBackGroundService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var subscriptionCheckerService = scope.ServiceProvider.GetRequiredService<ISubscriptionCheckerService>();
                        await subscriptionCheckerService.CheckConditionAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while executing subscription checker.");
                }

                // Delay for a specific time before checking again
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}
