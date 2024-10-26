using FinanceTracker.Api.Model.Database;

namespace FinanceTracker.Api.Infrastructure;

public interface IInvestmentRepository
{
    Task<MonthlyRecord> GetByIdAsync(Guid id);
    // Task<IEnumerable<MonthlyRecord>> GetAllAsync();
    Task AddAsync(MonthlyRecord monthlyRecord);
    // Task UpdateAsync(MonthlyRecord monthlyRecord);
    // Task DeleteAsync(int id);
}