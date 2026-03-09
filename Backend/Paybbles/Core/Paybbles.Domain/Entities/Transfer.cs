namespace Paybbles.Domain.Entities
{
    public class Transfer : AuditableEntity
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int Value { get; private set; }
        public int Year { get; private set; }
        public int Month { get; private set; }

        protected Transfer() { }

        public Transfer(Guid userId, string description, int value, int year, int month)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("UserId must be valid.");

            UserId = userId;
            ChangeDescription(description);
            ChangeValue(value);
            ChangeYear(year);
            ChangeMonth(month);
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

        public void ChangeYear(int year)
        {
            if (year < 1)
                throw new ArgumentException("Year must be valid.");

            Year = year;
        }

        public void ChangeMonth(int month)
        {
            if (month < 1 || month > 12)
                throw new ArgumentException("Month must be between 1 and 12.");

            Month = month;
        }
    }
}
