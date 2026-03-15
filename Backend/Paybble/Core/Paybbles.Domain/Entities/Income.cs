using Paybble.Domain.Enums;

namespace Paybble.Domain.Entities
{
    public class Income : MonthlyEntry
    {
        public DateOnly? PaymentDate { get; private set; }

        protected Income() { }

        public Income(string description, int value, int year, int month, Recurrence recurrence, int frequency, DateOnly? PaymentDate)
            : base(description, value, year, month, recurrence, frequency)
        {
            ChangePaymentDate(PaymentDate);
        }

        public void ChangePaymentDate(DateOnly? paymentDate)
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
