namespace FinanceTracker.Api.Model.Response;

public class InvestmentResponse
{
    public Guid InvestmentId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Value { get; set; }
}