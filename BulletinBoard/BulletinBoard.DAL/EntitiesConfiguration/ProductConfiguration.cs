using BulletinBoard.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletinBoard.DAL.EntitiesConfiguration
{
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(b => b.Price)
                .IsRequired();
        }

        protected override void ConfigureForeignKeys(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(b => b.Category)
                .WithMany(b => b.Products)
                .HasForeignKey(b => b.CategoryId)
                .IsRequired();
        }
    }
}