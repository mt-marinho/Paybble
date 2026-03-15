using MediatR;
using Paybble.Application.Features.Incomes.Queries.GetIncomeDetail;

namespace Paybble.Application.Features.Incomes.Queries.GetIncome
{
    public record GetincomeDetailQuery(int id): IRequest<GetIncomeDetailResponse>;
}
