namespace FinanceTracker.Api.Model.Requests;

public class InvestmentRecordRequest
{
    public Guid InvestmentId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Value { get; set; }
    public Guid AccountId { get; set; }
}