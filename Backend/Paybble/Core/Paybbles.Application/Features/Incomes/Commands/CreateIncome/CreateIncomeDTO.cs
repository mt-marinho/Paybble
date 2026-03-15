using Paybble.Domain.Enums;

namespace Paybble.Application.Features.Incomes.Commands.CreateIncome
{
    public class CreateIncomeDTO
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int Value { get; private set; }
        public DateOnly? PaymentDate { get; set; }
    }
}
