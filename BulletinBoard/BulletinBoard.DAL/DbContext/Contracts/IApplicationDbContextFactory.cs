namespace BulletinBoard.DAL.DbContext.Contracts
{
    public interface IApplicationDbContextFactory
    {
        ApplicationDbContext Create();
    }
}