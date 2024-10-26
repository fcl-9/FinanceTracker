using FinanceTracker.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Api.Infrastructure.Repositories;

public class FinanceTrackerDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<MonthlyRecord> MonthlyRecords { get; set; }

    public FinanceTrackerDbContext(DbContextOptions<FinanceTrackerDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Define relationships and constraints
        modelBuilder.Entity<MonthlyRecord>()
            .HasOne(mr => mr.Account)
            .WithMany()
            .HasForeignKey(mr => mr.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}