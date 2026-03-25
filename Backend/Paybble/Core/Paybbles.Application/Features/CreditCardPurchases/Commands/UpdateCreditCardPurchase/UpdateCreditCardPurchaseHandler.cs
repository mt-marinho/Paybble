using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Application.Exceptions;
using Paybble.Domain.Entities;
using Paybble.Domain.Enums;

namespace Paybble.Application.Features.CreditCardPurchases.Commands.UpdateCreditCardPurchase
{
    public class UpdateCreditCardPurchaseHandler(ICreditCardPurchaseRepository purchaseRepository, ITransactionRepository transactionRepository) : IRequestHandler<UpdateCreditCardPurchaseCommand>
    {
        public async Task Handle(UpdateCreditCardPurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = await purchaseRepository.GetCreditCardPurchaseWithDetailsAsync(request.Id);
            if (purchase == null)
                throw new NotFoundException(nameof(CreditCardPurchase), request.Id);

            bool needsRegeneration = 
                purchase.TotalValue != request.TotalValue ||
                purchase.InstallmentsCount != request.InstallmentsCount ||
                purchase.FirstInstallmentDate != request.FirstInstallmentDate;

            purchase.ChangeDescription(request.Description);
            purchase.ChangeTotalValue(request.TotalValue);
            purchase.ChangeInstallmentsCount(request.InstallmentsCount);
            purchase.ChangePurchaseDate(request.PurchaseDate);
            purchase.ChangeFirstInstallmentDate(request.FirstInstallmentDate);

            if (needsRegeneration)
            {
                foreach (var transaction in purchase.Transactions.ToList())
                    await transactionRepository.DeleteAsync(transaction);
                

                decimal installmentValue = Math.Round(request.TotalValue / request.InstallmentsCount, 2);
                decimal remainder = request.TotalValue - (installmentValue * request.InstallmentsCount);

                for (int i = 0; i < request.InstallmentsCount; i++)
                {
                    decimal value = installmentValue;
                    if (i == 0) value += remainder;

                    var date = request.FirstInstallmentDate.AddMonths(i);
                    
                    var transaction = new Transaction(
                        $"{request.Description} ({i + 1}/{request.InstallmentsCount})",
                        value,
                        date.Year,
                        date.Month,
                        Recurrence.Installments,
                        request.InstallmentsCount, 
                        date,
                        TransferType.Withdraw, 
                        TransactionType.Expense, 
                        purchase.Id,
                        i + 1
                    );
                    
                    await transactionRepository.AddAsync(transaction);
                }
            }
            else
            {
                if (purchase.Transactions != null)
                {
                    foreach (var transaction in purchase.Transactions)
                    {
                         if (transaction.InstallmentNumber.HasValue)
                         {
                             transaction.ChangeDescription($"{request.Description} ({transaction.InstallmentNumber}/{request.InstallmentsCount})");
                             await transactionRepository.UpdateAsync(transaction);
                         }
                    }
                }
            }

            await purchaseRepository.UpdateAsync(purchase);
        }
    }
}
