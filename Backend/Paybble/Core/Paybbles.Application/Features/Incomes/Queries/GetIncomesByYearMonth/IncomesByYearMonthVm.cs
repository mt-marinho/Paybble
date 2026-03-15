namespace Paybble.Application.Features.Incomes.Queries.GetIncomesByYearMonth
{
    public class IncomesByYearMonthVm
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int Value { get; private set; }
        public DateOnly PaymentDate { get; set; }
    }
}
