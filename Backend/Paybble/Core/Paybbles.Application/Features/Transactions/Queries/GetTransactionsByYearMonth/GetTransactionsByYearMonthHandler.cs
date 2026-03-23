using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;

namespace Paybble.Application.Features.Transactions.Queries.GetTransactionsByYearMonth
{
    public class GetTransactionsByYearMonthHandler(ITransactionRepository transactionRepository, IMapper mapper) 
        : IRequestHandler<GetTransactionsByYearMonthQuery, TransactionsByYearMonthResponse>
    {
        public async Task<TransactionsByYearMonthResponse> Handle(GetTransactionsByYearMonthQuery request, CancellationToken cancellationToken)
        {
            var response = new TransactionsByYearMonthResponse();

            var transactions = await transactionRepository.GetTransactionsByYearMonthAsync(request.Year, request.Month);
            var transactionsByMonthVm = mapper.Map<List<TransactionsByYearMonthVm>>(transactions);

            response.Transactions = transactionsByMonthVm;
            return response;
        }
    }
}
