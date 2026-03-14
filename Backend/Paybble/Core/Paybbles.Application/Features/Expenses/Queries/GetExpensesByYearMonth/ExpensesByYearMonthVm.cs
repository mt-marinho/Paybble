using Paybble.Domain.Enums;

namespace Paybble.Application.Features.Expenses.Queries.GetExpensesByYearMonth
{
    public class ExpensesByYearMonthVm
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Value { get; set; }
        public Recurrence Recurrence { get; set; }
        public int Frequency { get; set; }
        public bool Paid { get; set; }
        public DateOnly DueDate { get; set; }
    }
}
