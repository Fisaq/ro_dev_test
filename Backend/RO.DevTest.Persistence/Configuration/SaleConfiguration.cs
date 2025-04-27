using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence.Configuration
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");
            builder.HasKey(s => s.SaleId);
            builder.Property(s => s.SaleDate).IsRequired();
            builder.Property(s => s.TotalValue).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasMany(s => s.SaleItems)
                   .WithOne(si => si.Sale)
                   .HasForeignKey(si => si.SaleId);
        }
    }
}
