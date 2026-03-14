using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Expenses.Commands.CreateExpense
{
    public class CreateExpenseCommandHandler(IExpensRepository expensRepository, IMapper mapper) : IRequestHandler<CreateExpenseCommand, CreateExpenseResponse>
    {
        public async Task<CreateExpenseResponse> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateExpenseResponse();

            var expense = new Expense(
                request.Description,
                request.Value,
                request.Year,
                request.Month,
                request.DueDate,
                request.Recurrence, 
                request.Frequency
            );

            var createdExpense = await expensRepository.AddAsync(expense);
            response.Expense = mapper.Map<CreateExpenseDTO>(createdExpense);
            return response;
        }
    }
}
