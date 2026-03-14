using Paybble.Domain.Enums;

namespace Paybble.Domain.Entities
{
    public class MonthlyEntry : AuditableEntity
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int Value { get; private set; }
        public int Year { get; private set; }
        public int Month { get; private set; }
        public Recurrence Recurrence { get; private set; }
        public int Frequency { get; private set; }

        protected MonthlyEntry() { }

        protected MonthlyEntry( string description, int value, int year, int month, Recurrence recurrence, int frequency)
        {
            ChangeDescription(description);
            ChangeValue(value);
            ChangeYear(year);
            ChangeMonth(month);
            ChangeRecurrence(recurrence, frequency);
        }

        public void ChangeRecurrence(Recurrence recurrence, int frequency)
        {
            if (recurrence != Recurrence.None && frequency < 1)
                throw new ArgumentException("Frequency must be at least 1.");

            Recurrence = recurrence;
            Frequency = recurrence == Recurrence.None ? 0 : frequency;
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
