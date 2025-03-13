using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace System.Master.Loyalty.Group.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderData>
    {
        public void Configure(EntityTypeBuilder<OrderData> builder)
        {
            builder.ToTable("Orders");
            builder.Property(element => element.Total).IsRequired();
            builder.HasOne(e => e.User).WithMany(e => e.Orders).HasForeignKey(e => e.UserId);
        }
    }
}
