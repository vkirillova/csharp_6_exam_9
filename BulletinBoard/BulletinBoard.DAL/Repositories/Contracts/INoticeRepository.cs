using System.Collections.Generic;
using BulletinBoard.DAL.Entities;

namespace BulletinBoard.DAL.Repositories.Contracts
{
    public interface INoticeRepository : IRepository<Notice>
    {
        IEnumerable<Notice> GetAllNotices();
        Notice GetNoticeById(int id);
    }
}
