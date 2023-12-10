using System.ComponentModel.DataAnnotations;

namespace StJosephBazaar.Models;

public class Year
{
    public int ID{get;set;}

    public string YearVal{get;set;}

    public DateOnly Friday{get; set;}

    public DateOnly Saturday{get;set;}
    public ICollection<Booth>? Booths { get; set; }
}