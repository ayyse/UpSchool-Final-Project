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

            // Common Fields

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId).IsRequired(false);
            builder.Property(x => x.CreatedByUserId).HasMaxLength(100);

            // ModifiedOn
            builder.Property(x => x.ModifiedOn).IsRequired(false);

            // ModifiedByUserId
            builder.Property(x => x.ModifiedByUserId).IsRequired(false);
            builder.Property(x => x.ModifiedByUserId).HasMaxLength(100);

            // DeletedOn
            builder.Property(x => x.DeletedOn).IsRequired(false);

            // DeletedByUserId
            builder.Property(x => x.DeletedByUserId).IsRequired(false);
            builder.Property(x => x.DeletedByUserId).HasMaxLength(100);

            // IsDeleted
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValueSql("0");
            builder.HasIndex(x => x.IsDeleted);

            //Relationships
            builder.HasOne<Order>(x => x.Order)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.OrderId);

            builder.ToTable("Products");
        }
    }
}
