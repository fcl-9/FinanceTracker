using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Infrastructure;

public class Account
{
    [Key]
    public Guid AccountId { get; set; }

    [Required]
    [MaxLength(100)]
    public string AccountName { get; set; }

    [Required]
    [MaxLength(100)]
    public string AccountProvider { get; set; }

    [Required]
    [MaxLength(50)]
    public string AccountType { get; set; }
}