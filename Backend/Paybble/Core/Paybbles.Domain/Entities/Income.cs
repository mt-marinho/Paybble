using Paybble.Domain.Enums;

namespace Paybble.Domain.Entities
{
    public class Income : MonthlyEntry
    {
        public DateOnly? PaymentDate { get; private set; }

        protected Income() { }

        public Income(Guid userId, string description, int value, int year, int month, Recurrence recurrence = Recurrence.None, int frequency = 1)
            : base(userId, description, value, year, month, recurrence, frequency)
        {
        }

        public void ChangePaymentDate(DateOnly paymentDate)
        {
            if (paymentDate == default)
                throw new ArgumentException("PaymentDate is required.");

            if (paymentDate > DateOnly.FromDateTime(DateTime.UtcNow))
                throw new ArgumentException("PaymentDate cannot be in the future.");

            PaymentDate = paymentDate;
        }

        public void ClearPaymentDate() => PaymentDate = null;
    }
}
