namespace Paybble.Domain.Entities
{
    public abstract class AuditableEntity
    {
        public Guid UserId { get; protected set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
