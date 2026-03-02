namespace Paybbles.Domain.Entities
{
    public class Expense : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Value { get; private set; }
        public bool Paid { get; set; }
        public int Month { get; private set; }
        public int YearLedgerId { get; private set; }
    }
}
