using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;

namespace Paybble.Application.Features.CreditCardPurchases.Commands.DeleteCreditCardPurchase
{
    public class DeleteCreditCardPurchaseHandler(ICreditCardPurchaseRepository purchaseRepository, ITransactionRepository transactionRepository) : IRequestHandler<DeleteCreditCardPurchaseCommand>
    {
        public async Task Handle(DeleteCreditCardPurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = await purchaseRepository.GetCreditCardPurchaseWithDetailsAsync(request.Id);
            if (purchase == null)
            {
                throw new NotFoundException(nameof(CreditCardPurchase), request.Id);
            }

            if (purchase.Transactions != null && purchase.Transactions.Any())
            {
                foreach (var transaction in purchase.Transactions.ToList())
                {
                    await transactionRepository.DeleteAsync(transaction);
                }
            }
            
            await purchaseRepository.DeleteAsync(purchase);
        }
    }
}
