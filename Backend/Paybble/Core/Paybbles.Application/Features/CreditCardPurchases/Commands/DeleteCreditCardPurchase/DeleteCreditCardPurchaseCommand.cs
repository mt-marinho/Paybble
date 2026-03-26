using MediatR;

namespace Paybble.Application.Features.CreditCardPurchases.Commands.DeleteCreditCardPurchase
{
    public record DeleteCreditCardPurchaseCommand(int id) : IRequest;
}
