namespace FinanceTracker.Infrastructure;

public interface IInvestmentTrackerRepository
{
    public Task AddAccount();
    public Task AddMonthlyTopUp();
}