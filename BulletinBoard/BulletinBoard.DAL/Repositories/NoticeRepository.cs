using System.Collections.Generic;
using System.Linq;
using BulletinBoard.DAL.DbContext;
using BulletinBoard.DAL.Entities;
using BulletinBoard.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.DAL.Repositories
{
    public class NoticeRepository : Repository<Notice>, INoticeRepository
    {
        public NoticeRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Notices;
        }

        public IEnumerable<Notice> GetAllNotices()
        {
            return entities
                .Include(e => e.User)
                .Include(e=>e.Title)
                .Include(e => e.ProductImages).ThenInclude(e=>e.Image)
                .Include(c => c.CreatedOn)
                .Include(e=>e.Description)
                .ToList();
            //return entities
            //    .Include(e => e.Author)
            //    .Include(e => e.Products)
            //    .ThenInclude(c => c.Author)
            //    .ToList();
        }

        public Notice GetNoticeById(int id)
        {
            //return entities
            //    .Include(e => e.Author)
            //    .Include(e => e.GalleryImages)
            //    .Include(e => e.Products)
            //    .ThenInclude(c => c.Author)
            //    .FirstOrDefault(c => c.Id == id);
            return entities
                .Include(e => e.User)
                .Include(e => e.ProductImages)
                .Include(e => e.Title)
                .Include(e => e.Description)
                .Include(e => e.CreatedOn)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
