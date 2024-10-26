using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Api.Model.Database;

public class MonthlyRecord
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public int Month { get; set; }

    [Required]
    public int Year { get; set; }

    [Required]
    public decimal Value { get; set; }

    // Foreign Key to Account
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
}