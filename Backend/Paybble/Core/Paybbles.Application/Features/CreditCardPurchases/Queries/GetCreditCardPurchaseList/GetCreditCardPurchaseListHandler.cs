using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.CreditCardPurchases.Queries.GetCreditCardPurchaseList
{
    public class GetCreditCardPurchaseListHandler : IRequestHandler<GetCreditCardPurchaseListQuery, List<CreditCardPurchaseListDTO>>
    {
        private readonly ICreditCardPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public GetCreditCardPurchaseListHandler(ICreditCardPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task<List<CreditCardPurchaseListDTO>> Handle(GetCreditCardPurchaseListQuery request, CancellationToken cancellationToken)
        {
            var purchases = await _purchaseRepository.ListAllAsync();
            return _mapper.Map<List<CreditCardPurchaseListDTO>>(purchases);
        }
    }
}
