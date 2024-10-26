using FinanceTracker.Infrastructure;

namespace FinanceTracker.Api.Model;

public class MonthlyRecordRequest
{
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Value { get; set; }

    public Guid AccountId { get; set; }
}