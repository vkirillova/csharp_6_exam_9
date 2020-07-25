namespace BulletinBoard.DAL.DbContext.Contracts
{
    public interface IUnitOfWorkFactory
    {
        UnitOfWork Create();
    }
}
