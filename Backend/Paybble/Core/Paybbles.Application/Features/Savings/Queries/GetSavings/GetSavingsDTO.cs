namespace Paybble.Application.Features.Savings.Queries.GetSavings
{
    public class GetSavingsDTO
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public decimal GoalValue { get; private set; }
    }
}
