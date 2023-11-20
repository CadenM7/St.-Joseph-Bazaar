using System.ComponentModel.DataAnnotations;

namespace StJosephBazaar.Models;

public class Comparison
{
    public int YearInit{get; set;}

    public int YearComp{get; set;}

    public decimal YIAdvance{get; set;}

    public decimal YCAdvance{get; set;}

    public decimal AdvanceVariance{get;set;}

    public decimal YIFriday{get; set;}

    public decimal YCFriday{get; set;}

    public decimal FridayVariance{get; set;}

    public decimal YISaturday{get;set;}

    public decimal YCSaturday{get;set;}

    public decimal SaturdayVariance{get;set;}

    public decimal YIAuct{get;set;}

    public decimal YCAuct{get;set;}

    public decimal AuctionVariance{get;set;}

    public decimal YINetIncome{get; set;}

    public decimal YCNetIncome{get; set;}

    public decimal NetVariance{get; set;}
}