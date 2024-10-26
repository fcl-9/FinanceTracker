namespace FinanceTracker.Api.Model;

public class AccountRequest
{
    public Guid AccountId { get; set; }
    public string? AccountName { get; set; }
    public string? AccountProvider { get; set; }
    public string? AccountType { get; set; }
}