using FinanceTracker.Api.Model.Database;

namespace FinanceTracker.Api.Infrastructure;

public interface IAccountRepository
{
    Task<Account> GetByIdAsync(Guid id);
    // Task<IEnumerable<Account>> GetAllAsync();
    Task AddAsync(Account account);
    // Task UpdateAsync(Account account);
    // Task DeleteAsync(Guid id);
}