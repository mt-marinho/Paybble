namespace Paybble.Application.Features.Savings.Commands.UpdateSavings
{
    public class UpdateSavingsDTO
    {
        public string Description { get; private set; } = string.Empty;
        public decimal GoalValue { get; private set; }
    }
}
