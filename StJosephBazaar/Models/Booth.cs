using System.ComponentModel.DataAnnotations;

namespace StJosephBazaar.Models;

public class Booth
{
    public int Id { get; set; }
    public string? Name { get; set; }
    // public decimal StartupTotal { get; set; }
    public decimal Friday { get; set; }
    
    public int YearID{get;set;}
    public decimal Saturday { get; set; }
    public decimal Auction { get; set; }
    public decimal Gross_Revenue {
        get 
        {
            return (decimal)(Friday + Saturday + Auction);
        }}
    public decimal Purchases { get; set; }
    public ICollection<Expense>? Expenses { get; set; }
    public ICollection<Income>? Income { get; set; }
    public decimal Net_Income {
        get 
        {
            return (decimal)(Gross_Revenue - Purchases);
        }
    }
    
}