using Paybble.Domain.Enums;

namespace Paybble.Application.Features.Transactions.Queries.GetTransactionsByYearMonth
{
    public class TransactionsByYearMonthVm
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public Recurrence Recurrence { get; set; }
        public int Frequency { get; set; }
        public bool Paid { get; set; }
        public DateOnly Date { get; set; }
        public TransactionType TransactionType { get; set; }
        public TransferType TransferType { get; set; }
    }
}
