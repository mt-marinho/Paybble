using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.Transactions.Queries.GetTransactionDetail
{
    public class GetTransactionDetailHandler(ITransactionRepository transactionRepository, IMapper mapper) 
        : IRequestHandler<GetTransactionDetailQuery, GetTransactionDetailResponse>
    {
        public async Task<GetTransactionDetailResponse> Handle(GetTransactionDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new GetTransactionDetailResponse();

            var transaction = await transactionRepository.GetByIdAsync(request.Id);

            if (transaction == null)
                throw new NotFoundException(nameof(Transaction), request.Id);

            response.Transaction = mapper.Map<TransactionDetailVm>(transaction);
            return response;
        }
    }
}
