using System.Collections.Generic;
using System.Threading.Tasks;
using BulletinBoard.DAL.Entities;

namespace BulletinBoard.DAL.Repositories.Contracts
{
    public interface IRepository<T> where T : class, IEntity
    {
        T Create(T entity);

        Task<T> CreateAsync(T entity);

        T GetById(int id);

        IEnumerable<T> GetAll();

        T Update(T entity);

        void Remove(T entity);
    }
}
