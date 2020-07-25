using BulletinBoard.DAL.Entities;

namespace BulletinBoard.DAL.EntitiesConfiguration.Contracts
{
    public interface IEntityConfigurationsContainer
    {
        IEntityConfiguration<Notice> NoticeConfiguration { get; }
        IEntityConfiguration<Product> ProductConfiguration { get; }
        IEntityConfiguration<Category> CategoryConfiguration { get; }
        IEntityConfiguration<GalleryImage> GalleryImageConfiguration { get; }
        IEntityConfiguration<Comment> CommentConfiguration { get; }
    }
}