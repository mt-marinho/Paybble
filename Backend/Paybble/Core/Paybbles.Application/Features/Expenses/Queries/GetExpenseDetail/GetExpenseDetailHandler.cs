using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Application.Features.Expenses.Queries.GetExpense;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Expenses.Queries.GetExpenseDetail
{
    public class GetExpenseDetailHandler(IExpensRepository expensRepository, IMapper mapper) : IRequestHandler<GetExpenseDetailQuery, GetExpenseDetailResponse>
    {
        public async Task<GetExpenseDetailResponse> Handle(GetExpenseDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new GetExpenseDetailResponse();

            var expense = await expensRepository.GetByIdAsync(request.id);
            if (expense == null)
                throw new NotFoundException(nameof(Expense), request.id);

            response.expense = mapper.Map<ExpenseDetailVm>(expense);
            return response;
        }
    }
}
