namespace Paybbles.Domain.Entities
{
    public class Income : MonthlyEntry
    {
        protected Income() { }

        public Income(string description, int value, int month, int yearLedgerId)
            : base(description, value, month, yearLedgerId)
        {
        }
    }
}
