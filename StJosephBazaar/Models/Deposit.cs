namespace StJosephBazaar.Models
{
    public class Deposit
    {
        public int ID { get; set; }
        public DateOnly Date { get; set; }

        //Cash
        public decimal Checks { get; set; }
        public decimal Twentys { get; set; }
        public decimal Tens { get; set; }
        public decimal Fives { get; set; }
        public decimal Ones { get; set; }

        // Change
        public decimal Quarters  { get; set; }
        public decimal Dimes { get; set; }
        public decimal Nickels { get; set; }
        public decimal Pennies { get; set; }

        public decimal Total_Change {
            get 
            {
            return (decimal)(Quarters + Dimes + Nickels + Pennies);
            }
        }
    }
}
