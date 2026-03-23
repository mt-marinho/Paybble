using MediatR;

namespace Paybble.Application.Features.CreditCardPurchases.Queries.GetCreditCardPurchaseList
{
    public class GetCreditCardPurchaseListQuery : IRequest<List<CreditCardPurchaseListDTO>>
    {
    }
}
