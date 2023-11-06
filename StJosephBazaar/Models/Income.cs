using System.ComponentModel.DataAnnotations;

namespace StJosephBazaar.Models;

public class Income
{
    [Key]
    public int BoothID { get; set; }
    public int ID { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly HourCollected { get; set; }
    public decimal Total { get; set; }
}