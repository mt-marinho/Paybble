namespace Paybble.Application.Features.Incomes.Queries.GetIncomeDetail
{
    public class IncomeDetailVm
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int Value { get; private set; }
        public DateOnly PaymentDate { get; set; }
    }
}
