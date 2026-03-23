using Paybble.Domain.Enums;

namespace Paybble.Domain.Entities
{
    public class Transaction : AuditableEntity
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public decimal Value { get; private set; }
        public int Year { get; private set; }
        public int Month { get; private set; }
        public Recurrence Recurrence { get; private set; }
        public int Frequency { get; private set; }
        public bool Paid { get; private set; }
        public DateOnly Date { get; private set; }
        public TransactionType TransactionType { get; set; }
        public TransferType TransferType { get; set; }
        public int? CreditCardPurchaseId { get; private set; }
        public int? InstallmentNumber { get; private set; }
        public CreditCardPurchase? CreditCardPurchase { get; private set; }

        protected Transaction() { }

        public Transaction(string description, decimal value, int year, int month, Recurrence recurrence, int frequency, DateOnly date, TransferType transferType, TransactionType transactionType, int? creditCardPurchaseId = null, int? installmentNumber = null)
        {
            ChangeDescription(description);
            ChangeValue(value);
            ChangeYear(year);
            ChangeMonth(month);
            ChangeRecurrence(recurrence, frequency);
            ChangeDate(date);
            ChangeTransferType(transferType);
            ChangetTransactionType(transactionType);
            if (creditCardPurchaseId.HasValue) ChangeCreditCardPurchase(creditCardPurchaseId.Value, installmentNumber);
            Paid = false;
        }

        public void ChangeCreditCardPurchase(int creditCardPurchaseId, int? installmentNumber)
        {
             CreditCardPurchaseId = creditCardPurchaseId;
             InstallmentNumber = installmentNumber;
        }

        public void ChangeRecurrence(Recurrence recurrence, int frequency)
        {
            if (recurrence != Recurrence.Single && frequency < 1)
                throw new ArgumentException("Frequency must be at least 1.");

            Recurrence = recurrence;
            Frequency = recurrence == Recurrence.Single ? 0 : frequency;
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.");

            Description = description.Trim();
        }

        public void ChangeValue(decimal value)
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

        public void ChangeDate(DateOnly date)
        {
            if (date == default)
                throw new ArgumentException("DueDate is required.");

            Date = date;
        }

        public void ChangeTransferType(TransferType type)
        {
            if (!Enum.IsDefined(typeof(TransferType), type))
                throw new ArgumentException("Transfer type invalid.");

            TransferType = type;
        }

        public void ChangetTransactionType(TransactionType type)
        {
            if (!Enum.IsDefined(typeof(TransferType), type))
                throw new ArgumentException("Transaction type invalid.");

            TransactionType = type;
        }

        public void MarkAsPaid() => Paid = true;

        public void MarkAsUnpaid() => Paid = false;
    }
}
