using BulletinBoard.DAL.Entities;
using BulletinBoard.DAL.EntitiesConfiguration.Contracts;

namespace BulletinBoard.DAL.EntitiesConfiguration
{
    public class EntityConfigurationsContainer : IEntityConfigurationsContainer
    {
        public IEntityConfiguration<Notice> NoticeConfiguration { get; }
        public IEntityConfiguration<Product> ProductConfiguration { get; }
        public IEntityConfiguration<GalleryImage> GalleryImageConfiguration { get; }
        public IEntityConfiguration<Category> CategoryConfiguration { get; }
        public IEntityConfiguration<Comment> CommentConfiguration { get; }

        public EntityConfigurationsContainer()
        {
            NoticeConfiguration = new NoticeConfiguration();
            ProductConfiguration = new ProductConfiguration();
            GalleryImageConfiguration = new GalleryImageConfiguration();
            CategoryConfiguration = new CategoryConfiguration();
            CommentConfiguration = new CommentConfiguration();
        }
    }
}
