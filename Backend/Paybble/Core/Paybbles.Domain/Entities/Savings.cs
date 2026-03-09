namespace Paybble.Domain.Entities
{
    public class Savings : AuditableEntity
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int Value { get; private set; }

        protected Savings() { }

        public Savings(Guid userId, string description, int value)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("UserId must be valid.");

            UserId = userId;
            ChangeDescription(description);
            ChangeValue(value);
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.");

            Description = description.Trim();
        }

        public void ChangeValue(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Value must be greater than zero.");

            Value = value;
        }
    }
}
