namespace Paybble.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;


        protected Category() { }

        public Category(string name)
        {
            ChangeName(name);
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");

            Name = name.Trim();
        }
    }
}
