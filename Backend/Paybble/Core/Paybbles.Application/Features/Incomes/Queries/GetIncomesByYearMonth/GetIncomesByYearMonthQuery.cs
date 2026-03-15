using MediatR;

namespace Paybble.Application.Features.Incomes.Queries.GetIncomesByYearMonth
{
    public record GetIncomesByYearMonthQuery(int id, int year, int month) : IRequest<GetIncomesByYearMonthResponse>;
}
