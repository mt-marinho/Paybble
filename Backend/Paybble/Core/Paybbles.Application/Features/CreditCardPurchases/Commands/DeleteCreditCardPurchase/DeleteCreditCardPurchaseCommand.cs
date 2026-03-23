using MediatR;

namespace Paybble.Application.Features.CreditCardPurchases.Commands.DeleteCreditCardPurchase
{
    public class DeleteCreditCardPurchaseCommand : IRequest
    {
        public int Id { get; set; }
    }
}
