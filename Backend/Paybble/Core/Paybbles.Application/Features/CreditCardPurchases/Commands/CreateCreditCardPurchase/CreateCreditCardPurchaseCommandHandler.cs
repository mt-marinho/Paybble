using AutoMapper;
using MediatR;
using Paybble.Application.Contracts.Persistence;
using Paybble.Domain.Entities;
using Paybble.Domain.Enums;

namespace Paybble.Application.Features.CreditCardPurchases.Commands.CreateCreditCardPurchase
{
    public class CreateCreditCardPurchaseCommandHandler(ICreditCardPurchaseRepository purchaseRepository, ITransactionRepository transactionRepository, IMapper mapper) : IRequestHandler<CreateCreditCardPurchaseCommand, CreateCreditCardPurchaseResponse>
    {
        public async Task<CreateCreditCardPurchaseResponse> Handle(CreateCreditCardPurchaseCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCreditCardPurchaseResponse();

            var purchase = new CreditCardPurchase(
                request.Description,
                request.TotalValue,
                request.InstallmentsCount,
                request.PurchaseDate,
                request.FirstInstallmentDate
            );

            purchase = await purchaseRepository.AddAsync(purchase);

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

            response.CreditCardPurchase = mapper.Map<CreateCreditCardPurchaseDTO>(purchase);
            return response;
        }
    }
}
