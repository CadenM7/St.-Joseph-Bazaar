using System.ComponentModel.DataAnnotations;

namespace StJosephBazaar.Models{

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
    [DataType(DataType.Date)]
    public decimal StartupTotal { get; set; }
}
}