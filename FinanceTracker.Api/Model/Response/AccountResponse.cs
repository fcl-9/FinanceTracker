﻿namespace FinanceTracker.Api.Model.Response;

public class AccountResponse
{
    public Guid AccountId { get; set; }
    public string? AccountName { get; set; }
    public string? AccountProvider { get; set; }
    public string? AccountType { get; set; }
}