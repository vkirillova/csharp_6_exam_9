using BulletinBoard.DAL.DbContext;
using BulletinBoard.DAL.Entities;
using BulletinBoard.DAL.Repositories.Contracts;

namespace BulletinBoard.DAL.Repositories
{
    public class GalleryImageRepository : Repository<GalleryImage>, IGalleryImageRepository
    {
        public GalleryImageRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.GalleryImages;
        }
    }
}