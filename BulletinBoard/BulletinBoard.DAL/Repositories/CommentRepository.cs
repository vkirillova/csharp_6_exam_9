using BulletinBoard.DAL.DbContext;
using BulletinBoard.DAL.Entities;
using BulletinBoard.DAL.Repositories.Contracts;

namespace BulletinBoard.DAL.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Comments;
        }
    }
}