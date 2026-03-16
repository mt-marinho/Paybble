namespace Paybble.Application.Features.Savings.Commands.CreateSavings
{
    public class CreateSavingsDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int GoalValue { get; set; }
        public int Progress { get; set; }
    }
}
