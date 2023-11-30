namespace StJosephBazaar.Models
{
    public class Deposit
    {
        public int ID { get; set; }
        public DateOnly Date { get; set; }

        //Cash
        public decimal Checks { get; set; }
        public int Twentys { get; set; }
        public int Tens { get; set; }
        public int Fives { get; set; }
        public int Ones { get; set; }

        // Change
        public double Quarters  { get; set; }
        public double Dimes { get; set; }
        public double Nickels { get; set; }
        public double Pennies { get; set; }

        public decimal Total_Change {
            get 
            {
            return (decimal)((Quarters * 0.25) + (Dimes* 0.10) + (Nickels * 0.05) + (Pennies * 0.01));
            }
        }
    }
}
