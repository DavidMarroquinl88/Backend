using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace System.Master.Loyalty.Group.Data.Configuration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<ArticleData>
    {
        public void Configure(EntityTypeBuilder<ArticleData> builder)
        {
            builder.ToTable("Articles");
            builder.Property(element => element.Code).IsRequired().HasMaxLength(5);
            builder.Property(element => element.Name).IsRequired().HasMaxLength(250).IsRequired();
            builder.Property(element => element.Description).IsRequired().HasMaxLength(500).IsRequired();
            builder.Property(element => element.Price).IsRequired();
            builder.Property(element => element.ImageName).IsRequired().HasMaxLength(250);
            builder.Property(element => element.ImageUrl).IsRequired().HasMaxLength(500);
        }
    }
}
