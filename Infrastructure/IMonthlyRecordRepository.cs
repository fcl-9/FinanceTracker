namespace FinanceTracker.Infrastructure.FinanceTracker.Model;

public interface IMonthlyRecordRepository
{
    // Task<MonthlyRecord> GetByIdAsync(int id);
    // Task<IEnumerable<MonthlyRecord>> GetAllAsync();
    Task AddAsync(MonthlyRecord monthlyRecord);
    // Task UpdateAsync(MonthlyRecord monthlyRecord);
    // Task DeleteAsync(int id);
}