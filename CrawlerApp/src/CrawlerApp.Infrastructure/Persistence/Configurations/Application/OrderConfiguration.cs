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

            // Relationships
            //builder.HasMany<OrderEvent>(x => x.OrderEvents)
            //    .WithOne(x => x.Order)
            //    .HasForeignKey(x => x.OrderId);

            builder.ToTable("Orders");
        }
    }
}
