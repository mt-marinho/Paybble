using MediatR;

namespace Paybble.Application.Features.CreditCardPurchases.Queries.GetCreditCardPurchaseDetail
{
    public class GetCreditCardPurchaseDetailQuery : IRequest<CreditCardPurchaseDetailDTO>
    {
        public int Id { get; set; }
    }
}
