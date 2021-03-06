using ef_core_anonymous_table.Models;
using Microsoft.EntityFrameworkCore;

namespace ef_core_anonymous_table.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<PriceUpdateView> PriceUpdateViews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PriceUpdateView>()
                .ToView(nameof(PriceUpdateView))
                .HasKey(p => p.Id);
        }

    }
}
