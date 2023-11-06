using System.ComponentModel.DataAnnotations;

namespace StJosephBazaar.Models;

public class Expense
{
    [Key]
    public int BoothID { get; set; }
    public DateOnly Date { get; set; }
    public string? Description { get; set; }
    public decimal Total { get; set;}
}