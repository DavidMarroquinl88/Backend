using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace System.Master.Loyalty.Group.Data.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetailData>
    {
        public void Configure(EntityTypeBuilder<OrderDetailData> builder)
        {
            builder.ToTable("OrderDetails");

            builder.Property(e => e.Quantity).IsRequired();

            builder.HasOne(e => e.Order).WithMany(e => e.OrderDetails).HasForeignKey(e => e.OrderId).IsRequired();

            builder.HasOne(e => e.Article).WithMany(e => e.OrderDetails).HasForeignKey(e => e.ArticleId).IsRequired();
        }
    }
}
