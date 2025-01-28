using Microsoft.EntityFrameworkCore;


namespace ViTest.Domain
{
    public class ViTestDbContext : DbContext
    {
        public DbSet<MoneyArrival> MoneyArrivals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public ViTestDbContext(DbContextOptions<ViTestDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payments", tb => tb.HasTrigger("trg_UpdateOrderAndMoneyArrival"));
            });
        }
    }
}
