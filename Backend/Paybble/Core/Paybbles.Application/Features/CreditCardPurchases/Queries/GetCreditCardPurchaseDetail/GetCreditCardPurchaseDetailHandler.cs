using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.CreditCardPurchases.Queries.GetCreditCardPurchaseDetail
{
    public class GetCreditCardPurchaseDetailHandler : IRequestHandler<GetCreditCardPurchaseDetailQuery, CreditCardPurchaseDetailDTO>
    {
        private readonly ICreditCardPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public GetCreditCardPurchaseDetailHandler(ICreditCardPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task<CreditCardPurchaseDetailDTO> Handle(GetCreditCardPurchaseDetailQuery request, CancellationToken cancellationToken)
        {
            var purchase = await _purchaseRepository.GetCreditCardPurchaseWithDetailsAsync(request.Id);
            if (purchase == null)
            {
                throw new NotFoundException(nameof(CreditCardPurchase), request.Id);
            }

            return _mapper.Map<CreditCardPurchaseDetailDTO>(purchase);
        }
    }
}
