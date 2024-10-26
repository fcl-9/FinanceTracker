﻿using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Infrastructure;

public class MonthlyRecord
{
    [Key]
    public int Id { get; set; }

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