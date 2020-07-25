using System;
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
using Microsoft.AspNetCore.Mvc.Rendering;

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
                    .SearchByKeyWord(model.SearchKey)
                    .ByPriceFrom(model.PriceFrom)
                    .ByPriceTo(model.PriceTo)
                    .ByCategoryId(unitOfWork, model.CategoryId);

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
        public NoticeCreateModel GetNoticeCreateModel()
        {
            return new NoticeCreateModel()
            {
                CategoriesSelect = GetCategoriesSelect()
            };
        }

        public void CreateNotice(NoticeCreateModel model, int currentUserId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var record = Mapper.Map<Notice>(model);
                record.UserId = currentUserId;

                _fileSaver.SaveFile(record, model.Image);

                unitOfWork.Notices.Create(record);
            }
        }

        public int AddLike(int noticeId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var record = unitOfWork.Notices.GetById(noticeId);
                record.Likes++;
                unitOfWork.Notices.Update(record);
                return record.Likes;
            }
        }

        public NoticeModel GetNoticeById(in int noticeId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var notice = unitOfWork.Notices.GetNoticeById(noticeId);
                var model = Mapper.Map<NoticeEditModel>(notice);
                var categories = unitOfWork.Categories.GetAll().ToList();
                model.CategoriesSelect = new SelectList(
                    categories,
                    nameof(Category.Id),
                    nameof(Category.Name),
                    model.CategoryId);

                return Mapper.Map<NoticeModel>(notice);
            }
        }

        public CommentModel AddComment(AddCommentRequestModel model, User user)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var comment = Mapper.Map<Comment>(model);
                comment.AuthorId = user.Id;
                comment.CreatedOn = DateTime.Now;
                unitOfWork.Comments.CreateAsync(comment);
                comment.Author = user;
                return Mapper.Map<CommentModel>(comment);
            }
        }

        public IEnumerable<GalleryImageModel> UploadImages(AddGalleryImageModel model)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                foreach (var image in model.Images)
                {
                    var galleryImage = new GalleryImage()
                    {
                        NoticeId = model.NoticeId,
                        Name = image.FileName,
                        Image = _dbFileSaver.GetImageBytes(image)
                    };
                    unitOfWork.GalleryImages.Create(galleryImage);
                    yield return new GalleryImageModel()
                    {
                        Image = galleryImage.Image,
                        Name = galleryImage.Name
                    };
                }
            }
        }

        public SelectList GetCategoriesSelect()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var categories = unitOfWork.Categories.GetAll().ToList();
                return new SelectList(categories, nameof(Category.Id), nameof(Category.Name));
            }
        }

        public void EditNotice(NoticeEditModel model)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var notice = Mapper.Map<Notice>(model);
                unitOfWork.Notices.Update(notice);
            }
        }
    }
}