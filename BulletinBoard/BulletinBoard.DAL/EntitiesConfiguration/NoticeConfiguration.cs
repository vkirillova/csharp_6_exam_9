using BulletinBoard.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletinBoard.DAL.EntitiesConfiguration
{
    public class NoticeConfiguration : BaseEntityConfiguration<Notice>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Notice> builder)
        {
            builder
                .Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(b => b.Description)
                .HasMaxLength(1000);
        }

        protected override void ConfigureForeignKeys(EntityTypeBuilder<Notice> builder)
        {
            builder
                .HasOne(b => b.User)
                .WithMany(b => b.Notices)
                .HasForeignKey(b => b.UserId)
                .IsRequired();

            builder
                .HasMany(r => r.ProductImages)
                .WithOne(r => r.Notice)
                .HasForeignKey(r => r.NoticeId);
            builder
                .HasOne(b => b.Category)
                .WithMany(b => b.Notices)
                .HasForeignKey(b => b.CategoryId)
                .IsRequired();
        }
    }
}
