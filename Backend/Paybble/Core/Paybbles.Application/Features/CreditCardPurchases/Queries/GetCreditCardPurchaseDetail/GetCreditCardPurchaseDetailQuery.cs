using MediatR;

namespace Paybble.Application.Features.CreditCardPurchases.Queries.GetCreditCardPurchaseDetail
{
    public record GetCreditCardPurchaseDetailQuery(int id) : IRequest<CreditCardPurchaseDetailDTO>;
}
