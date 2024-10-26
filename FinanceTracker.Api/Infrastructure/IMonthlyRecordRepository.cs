namespace FinanceTracker.Infrastructure.FinanceTracker.Model;

public interface IMonthlyRecordRepository
{
    Task<MonthlyRecord> GetByIdAsync(Guid id);
    // Task<IEnumerable<MonthlyRecord>> GetAllAsync();
    Task AddAsync(MonthlyRecord monthlyRecord);
    // Task UpdateAsync(MonthlyRecord monthlyRecord);
    // Task DeleteAsync(int id);
}