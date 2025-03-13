using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace System.Master.Loyalty.Group.Data.Configuration
{
    public class BranchConfiguration : IEntityTypeConfiguration<BranchData>
    {
        public void Configure(EntityTypeBuilder<BranchData> builder)
        {
            builder.ToTable("Branch");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(500);

        }
    }
}
