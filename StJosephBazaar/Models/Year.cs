using System.ComponentModel.DataAnnotations;

namespace StJosephBazaar.Models;

public class Year
{
    public int YearID{get;set;}

    public int YearVal{get;set;}
    public ICollection<Booth>? Booths { get; set; }
}