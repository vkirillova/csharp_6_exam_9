using BulletinBoard.DAL.DbContext;
using BulletinBoard.DAL.Entities;
using BulletinBoard.DAL.Repositories.Contracts;

namespace BulletinBoard.DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Products;
        }
    }
}