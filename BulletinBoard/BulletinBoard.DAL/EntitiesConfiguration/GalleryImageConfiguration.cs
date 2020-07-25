using BulletinBoard.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletinBoard.DAL.EntitiesConfiguration
{
    public class GalleryImageConfiguration : BaseEntityConfiguration<GalleryImage>
    {
        protected override void ConfigureForeignKeys(EntityTypeBuilder<GalleryImage> builder)
        {
            builder
                .HasOne(b => b.Notice)
                .WithMany(b => b.ProductImages)
                .HasForeignKey(b => b.NoticeId);
        }
    }
}