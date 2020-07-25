using BulletinBoard.DAL.DbContext;
using BulletinBoard.DAL.Entities;
using BulletinBoard.DAL.Repositories.Contracts;

namespace BulletinBoard.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Categories;
        }
    }
}