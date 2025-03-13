using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace System.Master.Loyalty.Group.Data.Configuration
{
    public class StoreCongiration : IEntityTypeConfiguration<StoreData>
    {
        public void Configure(EntityTypeBuilder<StoreData> builder)
        {
            builder.ToTable("Stores");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(500);
            builder.HasOne(element => element.Branch).WithMany(element => element.Stores).HasForeignKey(element => element.BranchId).IsRequired();

        }
    }
}
