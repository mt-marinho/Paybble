using Paybble.Domain.Commom;
using Paybble.Domain.Enums;

namespace Paybble.Domain.Entities
{
    public class CreditCardPurchase : AuditableEntity
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public decimal TotalValue { get; private set; }
        public int InstallmentsCount { get; private set; }
        public DateOnly PurchaseDate { get; private set; }
        public DateOnly FirstInstallmentDate { get; private set; }
        public ICollection<Transaction> Transactions { get; private set; }

        protected CreditCardPurchase() 
        {
            Transactions = new List<Transaction>();
        }

        public CreditCardPurchase(string description, decimal totalValue, int installmentsCount, DateOnly purchaseDate, DateOnly firstInstallmentDate)
        {
            ChangeDescription(description);
            ChangeTotalValue(totalValue);
            ChangeInstallmentsCount(installmentsCount);
            ChangePurchaseDate(purchaseDate);
            ChangeFirstInstallmentDate(firstInstallmentDate);
            Transactions = new List<Transaction>();
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.");

            Description = description.Trim();
        }

        public void ChangeTotalValue(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("Total value must be greater than zero.");

            TotalValue = value;
        }

        public void ChangeInstallmentsCount(int count)
        {
            if (count < 1)
                throw new ArgumentException("Installments count must be at least 1.");

            InstallmentsCount = count;
        }

        public void ChangePurchaseDate(DateOnly date)
        {
            if (date == default)
                throw new ArgumentException("Purchase date is required.");

            PurchaseDate = date;
        }

        public void ChangeFirstInstallmentDate(DateOnly date)
        {
            if (date == default)
                throw new ArgumentException("First installment date is required.");

            FirstInstallmentDate = date;
        }
    }
}
