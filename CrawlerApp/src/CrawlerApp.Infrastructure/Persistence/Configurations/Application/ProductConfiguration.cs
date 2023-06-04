using CrawlerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CrawlerApp.Infrastructure.Persistence.Configurations.Application
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // ID
            builder.HasKey(x => x.Id);

            // Name
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(150);
            builder.HasIndex(x => x.Name);

            // Picture
            builder.Property(x => x.Picture).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(150);

            // IsOnSale
            builder.Property(x => x.IsOnSale).IsRequired();

            // Price
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(11,4)");

            // SalePrice
            builder.Property(x => x.SalePrice).IsRequired(false);
            builder.Property(x => x.SalePrice).HasColumnType("decimal(11,4)");

            //Relationships
            builder.HasOne<Order>(x => x.Order)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.OrderId);

            builder.ToTable("Products");
        }
    }
}
