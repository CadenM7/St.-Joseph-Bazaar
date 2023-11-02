using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Pkcs;

namespace StJosephBazaar.Models;

public class Startup
{
    public int ID { get; set; }
    public string? BoothName { get; set;}
    public int Twenties { get; set; }
    public int Tens { get; set; }
    public int Fives { get; set; }
    public int Ones { get; set; }
    public int Quarters { get; set; }
    public decimal Total {
        get
        {
            return (decimal)(Twenties * 20 + Tens * 10 + Fives * 5 + Ones + Quarters * .25);
        }
    }
}