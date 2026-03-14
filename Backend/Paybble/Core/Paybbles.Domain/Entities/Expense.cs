using Paybble.Domain.Enums;

namespace Paybble.Domain.Entities
{
    public class Expense : MonthlyEntry
    {
        public bool Paid { get; private set; }
        public DateOnly DueDate { get; private set; }

        protected Expense() { }

        public Expense(string description, int value, int year, int month, DateOnly dueDate, Recurrence recurrence, int frequency)
            : base(description, value, year, month, recurrence, frequency)
        {
            ChangeDueDate(dueDate);
            Paid = false;
        }

        public void ChangeDueDate(DateOnly dueDate)
        {
            if (dueDate == default)
                throw new ArgumentException("DueDate is required.");

            DueDate = dueDate;
        }

        public void MarkAsPaid() => Paid = true;

        public void MarkAsUnpaid() => Paid = false;
    }
}
