using System;
using BulletinBoard.DAL.Repositories;
using BulletinBoard.DAL.Repositories.Contracts;

namespace BulletinBoard.DAL.DbContext
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;

        public INoticeRepository Notices { get; set; }
        public IProductRepository Products { get; set; }
        public IGalleryImageRepository GalleryImages { get; set; }
        public ICategoryRepository Categories { get; set; }
        public ICommentRepository Comments { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Notices = new NoticeRepository(context);
            Products = new ProductRepository(context);
            GalleryImages = new GalleryImageRepository(context);
            Categories = new CategoryRepository(context);
            Comments = new CommentRepository(context);
        }

        #region Disposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _context.Dispose();

            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
