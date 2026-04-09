using Microsoft.EntityFrameworkCore;
using Paybble.Domain.Commom;
using Paybble.Domain.Entities;

namespace Paybble.Persistence
{
    public class PaybbleDbComtext : DbContext
    {
        private static readonly TimeZoneInfo _localTimeZone =
            TimeZoneInfo.FindSystemTimeZoneById("America/Campo_Grande");
        public PaybbleDbComtext(DbContextOptions<PaybbleDbComtext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CreditCardPurchase> CreditCardPurchases { get; set; }
        public DbSet<Saving> Savings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _localTimeZone);
                    //if (string.IsNullOrEmpty(entry.Entity.RF))
                    //    entry.Entity.RF = _currentUserService?.GetRfFromToken() ?? string.Empty;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("paybble");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaybbleDbComtext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
