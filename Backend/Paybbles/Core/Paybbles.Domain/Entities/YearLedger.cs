namespace Paybbles.Domain.Entities
{
    public class YearLedger : AuditableEntity
    {
        public int Id { get; set; }
        public int Year { get; private set; }
        public int UserId { get; set; }

        protected YearLedger() { }

        public YearLedger(int year, int userId)
        {
            ChangeYear(year);
            UserId = userId;
        }

        public void ChangeYear(int year)
        {
            if (year < 1900 || year > 2100)
                throw new ArgumentException("Year must be between 1900 and 2100.");
            Year = year;
        }
    }
}
