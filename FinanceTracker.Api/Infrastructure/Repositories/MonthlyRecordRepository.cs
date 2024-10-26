using FinanceTracker.Api.Model.Database;

namespace FinanceTracker.Api.Infrastructure.Repositories;

public class MonthlyRecordRepository : IMonthlyRecordRepository
{
    private readonly FinanceTrackerDbContext _context;

    public MonthlyRecordRepository(FinanceTrackerDbContext context)
    {
        _context = context;
    }

    public async Task<MonthlyRecord> GetByIdAsync(Guid id)
    {
        return await _context.MonthlyRecords.FindAsync(id);
    }
    //
    // public async Task<IEnumerable<MonthlyRecord>> GetAllAsync()
    // {
    //     return await _context.MonthlyRecords.Include(mr => mr.Account).ToListAsync();
    // }

    public async Task AddAsync(MonthlyRecord monthlyRecord)
    {
        _context.MonthlyRecords.Add(monthlyRecord);
        await _context.SaveChangesAsync();
    }
    //
    // public async Task UpdateAsync(MonthlyRecord monthlyRecord)
    // {
    //     _context.MonthlyRecords.Update(monthlyRecord);
    //     await _context.SaveChangesAsync();
    // }
    //
    // public async Task DeleteAsync(int id)
    // {
    //     var record = await _context.MonthlyRecords.FindAsync(id);
    //     if (record != null)
    //     {
    //         _context.MonthlyRecords.Remove(record);
    //         await _context.SaveChangesAsync();
    //     }
    // }
}