using System.ComponentModel.DataAnnotations;

namespace StJosephBazaar.Models;

public class Booth
{
    public int Id { get; set; }
    public string? Name { get; set; }
    // public decimal StartupTotal { get; set; }
    public decimal Friday { get; set; }
    public decimal Saturday { get; set; }
    public decimal Auction { get; set; }
    public decimal Gross_Revenue { get; set; }
    public ICollection<Expense>? Expenses { get; set; }
    public ICollection<Income>? Net_Incomes { get; set; }
}