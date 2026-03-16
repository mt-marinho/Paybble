namespace Paybble.Domain.Entities
{
    public class Saving : AuditableEntity
    {
        public int Id { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int GoalValue { get; private set; }

        protected Saving() { }

        public Saving(string description, int goalValue)
        {
            ChangeDescription(description);
            ChangeGoalValue(goalValue);
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.");

            Description = description.Trim();
        }

        public void ChangeGoalValue(int goalValue)
        {
            if (goalValue <= 0)
                throw new ArgumentException("Value must be greater than zero.");

            GoalValue = goalValue;
        }
    }
}
