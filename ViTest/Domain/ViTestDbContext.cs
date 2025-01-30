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
                entity.HasKey(e => e.PaymentId);
                entity.Property(o => o.PaymentId).ValueGeneratedOnAdd();
                entity.ToTable("Payments", tb => tb.HasTrigger("trg_UpdateOrderAndMoneyArrival"));
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);
            });

            modelBuilder.Entity<MoneyArrival>(entity =>
            {
                entity.HasKey(e => e.ArrivalId);
            });
        }
    }
}
