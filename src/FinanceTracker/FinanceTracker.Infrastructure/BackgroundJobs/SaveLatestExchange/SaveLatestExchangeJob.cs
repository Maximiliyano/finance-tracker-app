using FinanceTracker.Application.Exchanges.Service;
using FinanceTracker.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Quartz;

namespace FinanceTracker.Infrastructure.BackgroundJobs.SaveLatestExchange;

[DisallowConcurrentExecution]
public sealed class SaveLatestExchangeJob(
    IExchangeRepository repository,
    IUnitOfWork unitOfWork,
    IExchangeHttpService service,
    ILogger<SaveLatestExchangeJob> logger)
    : IJob
{
    public async Task Execute(IJobExecutionContext context) // TODO refactor job
    {
        logger.LogInformation("Save latest exchange background job has been started.");

        logger.LogInformation("Executing exchange from API...");

        var currentExchangesResult = await service.GetCurrencyAsync();

        if (!currentExchangesResult.IsSuccess)
        {
            logger.LogError("Error occured during executing exchange from API.");
            return;
        }

        logger.LogInformation("Executed exchange from API successfully.");
        logger.LogInformation("Adding / Updating current exchange...");

        if (currentExchangesResult.Value.Any())
        {
            // TODO update
        }
        else
        {
            repository.AddRange(currentExchangesResult.Value);
        }
        
        await unitOfWork.SaveChangesAsync(context.CancellationToken);

        logger.LogInformation("Current exchange has added.");
        logger.LogInformation("Save latest exchange background job has been finished successfully.");
    }
}
