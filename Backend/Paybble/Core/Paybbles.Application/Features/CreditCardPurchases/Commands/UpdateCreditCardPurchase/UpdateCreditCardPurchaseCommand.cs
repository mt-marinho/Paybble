using MediatR;

namespace Paybble.Application.Features.CreditCardPurchases.Commands.UpdateCreditCardPurchase
{
    public record UpdateCreditCardPurchaseCommand(
         int Id,
         string Description,
         decimal TotalValue,
         int InstallmentsCount,
         DateOnly PurchaseDate,
         DateOnly FirstInstallmentDate
        ) : IRequest;
}
