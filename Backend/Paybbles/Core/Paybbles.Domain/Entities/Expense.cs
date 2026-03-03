namespace Paybbles.Domain.Entities
{
    public class Expense : MonthlyEntry
    {
        public bool Paid { get; set; }

        protected Expense() { }

        public Expense(string description, int value, int month, int yearLedgerId)
            : base(description, value, month, yearLedgerId)
        {
            Paid = false;
        }
    }
}
