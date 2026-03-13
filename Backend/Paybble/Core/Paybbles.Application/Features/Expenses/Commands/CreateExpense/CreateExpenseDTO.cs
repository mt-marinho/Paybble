
namespace Paybble.Application.Features.Expenses .Commands.CreateExpense
{
    public class CreateExpenseDTO
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int Value { get; private set; }
        public bool Paid { get; private set; }
        public DateOnly DueDate { get; private set; }
    }
}
