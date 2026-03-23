using Paybble.Application.Responses;

namespace Paybble.Application.Features.CreditCardPurchases.Commands.CreateCreditCardPurchase
{
    public class CreateCreditCardPurchaseResponse : BaseResponse
    {
        public CreateCreditCardPurchaseResponse() : base()
        {
        }

        public CreateCreditCardPurchaseDTO CreditCardPurchase { get; set; }
    }
}
