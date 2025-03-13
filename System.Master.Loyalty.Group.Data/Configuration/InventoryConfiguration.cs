using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace System.Master.Loyalty.Group.Data.Configuration
{
    internal class InventoryConfiguration : IEntityTypeConfiguration<InventoryData>
    {
        public void Configure(EntityTypeBuilder<InventoryData> builder)
        {
            builder.ToTable("Inventories");
            builder.Property(element => element.Stock).IsRequired();
            builder.HasOne(element => element.Article).WithMany(element => element.Inventories).HasForeignKey(element => element.ArticleId);
            builder.HasOne(element => element.Store).WithMany(element => element.Inventories).HasForeignKey(element => element.StoreId);
        }
    }
}
