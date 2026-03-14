using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;

namespace Paybble.Application.Features.Expenses.Queries.GetExpensesByYearMonth
{
    public class GetExpensesByYearMonthHandler(IExpensRepository expensRepository, IMapper mapper) : IRequestHandler<GetExpensesByYearMonthQuery, ExpensesByYearMonthResponse>
    {
        public async Task<ExpensesByYearMonthResponse> Handle(GetExpensesByYearMonthQuery request, CancellationToken cancellationToken)
        {
            var response = new ExpensesByYearMonthResponse();

            var expenses = await expensRepository.GetExpensesByYearMonthAsync(request.year, request.month);
            var expensesByMonthVm = mapper.Map<List<ExpensesByYearMonthVm>>(expenses);

            response.expenses = expensesByMonthVm;
            return response;
        }
    }
}
