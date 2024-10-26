using FinanceTracker.Infrastructure;
using FinanceTracker.Infrastructure.FinanceTracker.Model;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Api.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly FinanceTrackerDbContext _context;

    public AccountRepository(FinanceTrackerDbContext context)
    {
        _context = context;
    }

    // public async Task<Account> GetByIdAsync(Guid id)
    // {
    //     return await _context.Accounts.FindAsync(id);
    // }
    //
    // public async Task<IEnumerable<Account>> GetAllAsync()
    // {
    //     return await _context.Accounts.ToListAsync();
    // }

    public async Task AddAsync(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
    }

    // public async Task UpdateAsync(Account account)
    // {
    //     _context.Accounts.Update(account);
    //     await _context.SaveChangesAsync();
    // }
    //
    // public async Task DeleteAsync(Guid id)
    // {
    //     var account = await _context.Accounts.FindAsync(id);
    //     if (account != null)
    //     {
    //         _context.Accounts.Remove(account);
    //         await _context.SaveChangesAsync();
    //     }
    // }
}