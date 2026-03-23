using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper) 
        : IRequestHandler<CreateTransactionCommand, CreateTransactionResponse>
    {
        public async Task<CreateTransactionResponse> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateTransactionResponse();

            var transaction = new Transaction(
                request.Description,
                request.Value,
                request.Year,
                request.Month,
                request.Recurrence,
                request.Frequency,
                request.Date,
                request.TransferType,
                request.TransactionType
            );

            var createdTransaction = await transactionRepository.AddAsync(transaction);
            response.Transaction = mapper.Map<CreateTransactionDTO>(createdTransaction);
            return response;
        }
    }
}
