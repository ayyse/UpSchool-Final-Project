using CrawlerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrawlerApp.Infrastructure.Persistence.Configurations.Application
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // ID
            builder.HasKey(x => x.Id);

            // RequestedAmount
            //builder.Property(x => x.RequestedAmount).IsRequired();

            //// TotalFoundAmount
            //builder.Property(x => x.TotalFoundAmount).IsRequired();

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

            // Relationships
            //builder.HasMany<OrderEvent>(x => x.OrderEvents)
            //    .WithOne(x => x.Order)
            //    .HasForeignKey(x => x.OrderId);

            builder.ToTable("Orders");
        }
    }
}
