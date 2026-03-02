namespace Paybbles.Domain.Entities
{
    public class YearLedger : AuditableEntity
    {
        public int Id { get; set; }
        public int Year { get; private set; }
        public int UserId { get; set; }
    }
}
