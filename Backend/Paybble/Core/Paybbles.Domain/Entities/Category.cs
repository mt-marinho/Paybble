namespace Paybble.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public string? Icon { get; private set; }
        public string? Color { get; private set; }

        protected Category() { }

        public Category(string name, string? description = null, string? icon = null, string? color = null)
        {
            ChangeName(name);
            ChangeDescription(description);
            ChangeIcon(icon);
            ChangeColor(color);
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");

            Name = name.Trim();
        }

        public void ChangeDescription(string? description)
        {
            Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
        }

        public void ChangeIcon(string? icon)
        {
            Icon = string.IsNullOrWhiteSpace(icon) ? null : icon.Trim();
        }

        public void ChangeColor(string? color)
        {
            Color = string.IsNullOrWhiteSpace(color) ? null : color.Trim();
        }
    }
}
