using System.Linq;
using BulletinBoard.DAL.Entities;
using BulletinBoard.DAL.EntitiesConfiguration.Contracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.DAL.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        private readonly IEntityConfigurationsContainer _entityConfigurationsContainer;

        public DbSet<Notice> Notices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IEntityConfigurationsContainer entityConfigurationsContainer) : base(options)
        {
            _entityConfigurationsContainer = entityConfigurationsContainer;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity(_entityConfigurationsContainer.NoticeConfiguration.ProvideConfigurationAction());
            builder.Entity(_entityConfigurationsContainer.ProductConfiguration.ProvideConfigurationAction());
            builder.Entity(_entityConfigurationsContainer.GalleryImageConfiguration.ProvideConfigurationAction());
            builder.Entity(_entityConfigurationsContainer.CategoryConfiguration.ProvideConfigurationAction());
            builder.Entity(_entityConfigurationsContainer.CommentConfiguration.ProvideConfigurationAction());

            DisableOneToManyCascadeDelete(builder);
        }

        private void DisableOneToManyCascadeDelete(ModelBuilder builder)
        {
            foreach (var relation in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}