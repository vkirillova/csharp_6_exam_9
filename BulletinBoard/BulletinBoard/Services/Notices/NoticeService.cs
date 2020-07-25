using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BulletinBoard.DAL.DbContext.Contracts;
using BulletinBoard.DAL.Entities;
using BulletinBoard.Models.Comments;
using BulletinBoard.Models.GalleryImages;
using BulletinBoard.Models.Notices;
using BulletinBoard.Services.GalleryImages;
using BulletinBoard.Services.GalleryImages.Contracts;
using BulletinBoard.Services.Notices.Contracts;

namespace BulletinBoard.Services.Notices
{
    public class NoticeService: INoticeService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFileSaver _fileSaver;
        private readonly DbFilesSaver _dbFileSaver;

        public NoticeService(IUnitOfWorkFactory unitOfWorkFactory, IFileSaver fileSaver, DbFilesSaver dbFileSaver)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _fileSaver = fileSaver;
            _dbFileSaver = dbFileSaver;
        }

        public List<NoticeModel> GetAllNotices(NoticeIndexModel model)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var notices = unitOfWork.Notices.GetAllNotices();

                notices = notices
                    .BySearchKey(model.SearchKey)
                    .ByAuthorName(model.Author)
                    .ByDateFrom(model.DateFrom)
                    .ByDateTo(model.DateTo);

                int pageSize = 10;
                int count = notices.Count();
                int page = model.Page.HasValue ? model.Page.Value : 1;
                notices = notices.Skip((page - 1) * pageSize).Take(pageSize);
                model.PagingModel = new PagingModel(count, page, pageSize);
                model.Page = page;

                var models = Mapper.Map<List<NoticeModel>>(notices.ToList());

                return models;
            }
        }

        public void CreateNotice(NoticeCreateModel model, int currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int AddLike(int noticeId)
        {
            throw new System.NotImplementedException();
        }

        public NoticeModel GetNoticeById(in int noticeId)
        {
            throw new System.NotImplementedException();
        }

        public CommentsModel AddComment(AddCommentRequestModel model, User user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<GalleryImageModel> UploadImages(AddGalleryImageModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}