namespace FinanceTracker.Model;

public class MonthlyRecordRequest
{
    // The month of the record (1 = January, 12 = December)
    public int Month { get; set; }

    // The year of the record
    public int Year { get; set; }

    // The value of the account at the end of this month
    public decimal Value { get; set; }
}