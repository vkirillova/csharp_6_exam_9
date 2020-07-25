using BulletinBoard.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletinBoard.DAL.EntitiesConfiguration
{
    public class CommentConfiguration : BaseEntityConfiguration<Comment>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Comment> builder)
        {
            builder
                .Property(b => b.Content)
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .Property(b => b.CreatedOn)
                .IsRequired();
        }

        protected override void ConfigureForeignKeys(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasOne(b => b.Author)
                .WithMany(b => b.Comments)
                .HasForeignKey(b => b.AuthorId)
                .IsRequired();

            builder
                .HasOne(c => c.Notice)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.NoticeId)
                .IsRequired();
        }
    }
}