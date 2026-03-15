using Paybble.Application.Responses;

namespace Paybble.Application.Features.Incomes.Commands.CreateIncome
{
    public class CreateIncomeReponse : BaseResponse
    {
        public CreateIncomeReponse() : base()
        { 
        }

        public CreateIncomeDTO income { get; set; }
    }
}
