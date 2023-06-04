using CrawlerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrawlerApp.Infrastructure.Persistence.Configurations.Application
{
    public class OrderEventConfiguration : IEntityTypeConfiguration<OrderEvent>
    {
        public void Configure(EntityTypeBuilder<OrderEvent> builder)
        {
            // ID
            builder.HasKey(x => x.Id);

            //Relationships
            builder.HasOne<Order>(x => x.Order)
                .WithMany(x => x.OrderEvents)
                .HasForeignKey(x => x.OrderId);

            builder.ToTable("OrderEvents");
        }

    }
}
