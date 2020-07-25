using BulletinBoard.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletinBoard.DAL.EntitiesConfiguration
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Category> builder)
        {
            builder
                .Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasIndex(b => b.Name)
                .IsUnique();
        }

        protected override void ConfigureForeignKeys(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasMany(b => b.Products)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .IsRequired();
            builder
                .HasMany(b => b.Notices)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .IsRequired();
        }
    }
}