namespace Paybbles.Domain.Entities
{
    public class Income : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; private set; } = string.Empty;
        public double Value { get; private set; }
        public int Month { get; private set; }
        public int YearLedgerId { get; private set; }

        public Income(string description, double value, int month, int yearLedgerId)
        {
            SetDescription(description);
            SetValue(value);
            SetMonth(month);
            SetYearLedger(yearLedgerId);
        }

        public void SetValue(double newValue)
        {
            if (newValue < 0)
                throw new ArgumentException("Value cannot be negative.");
            Value = newValue;
        }

        public void SetMonth(int newMonth)
        {
            if (newMonth < 1 || newMonth > 12)
                throw new ArgumentException("Month must be between 1 and 12.");
            Month = newMonth;
        }

        private void SetYearLedger(int yearLedgerId)
        {
            if (yearLedgerId <= 0) 
                throw new ArgumentException("YearLedgerId must be valid.");
            YearLedgerId = yearLedgerId;
        }

        private void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description is required.");
            Description = description.Trim();
        }
    }
}
