namespace Paybble.Application.Features.Incomes.Queries.GetIncomesByYearMonth
{
    public class GetIncomesByYearMonthResponse
    {
        public GetIncomesByYearMonthResponse() : base()
        {
        }

        public List<IncomesByYearMonthVm> incomes { get; set; }
    }
}
