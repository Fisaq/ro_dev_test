using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence.Configuration
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");
            builder.HasKey(si => si.SaleItemId);
            builder.Property(si => si.Quantity).IsRequired();
            builder.Property(si => si.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(si => si.TotalValue).IsRequired().HasColumnType("decimal(18,2)");
            // Relationships
            builder.HasOne(si => si.Sale)
                   .WithMany(s => s.SaleItems)
                   .HasForeignKey(si => si.SaleId);
            builder.HasOne(si => si.Product)
                   .WithMany()
                   .HasForeignKey(si => si.ProductId);
        }
    }
}
