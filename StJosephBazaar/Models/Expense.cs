using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StJosephBazaar.Models;

public class Expense
{
    public int BoothID { get; set; }
    public int ID { get; set; }
    public DateOnly Date { get; set; }
    public string? Description { get; set; }
    public double Total { get; set;}
    public int InvoiceNum { get; set; }
    public int CheckNum { get; set; }
    public Booth? Booth { get; set; }
}