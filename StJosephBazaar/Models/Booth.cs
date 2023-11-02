using System.ComponentModel.DataAnnotations;

namespace StJosephBazaar.Models;

public class Booth
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal StartupTotal { get; set; }
}