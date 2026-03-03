namespace Paybbles.Domain.Entities
{
    public class MonthlyEntry : AuditableEntity
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int Value { get; private set; }
        public int Month { get; private set; }
        public int YearLedgerId { get; private set; }

        protected MonthlyEntry() { }

        protected MonthlyEntry(string description, int value, int month, int yearLedgerId)
        {
            ChangeDescription(description);
            ChangeValue(value);
            ChangeMonth(month);
            ChangeYearLedger(yearLedgerId);
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.");

            Description = description.Trim();
        }

        public void ChangeValue(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Value must be greater than zero.");

            Value = value;
        }

        public void ChangeMonth(int month)
        {
            if (month < 1 || month > 12)
                throw new ArgumentException("Month must be between 1 and 12.");

            Month = month;
        }

        public void ChangeYearLedger(int yearLedgerId)
        {
            if (yearLedgerId <= 0)
                throw new ArgumentException("YearLedgerId must be valid.");

            YearLedgerId = yearLedgerId;
        }
    }
}
