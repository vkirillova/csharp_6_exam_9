using System.Collections.Generic;
using BulletinBoard.DAL.Entities;
using BulletinBoard.Models.Comments;
using BulletinBoard.Models.GalleryImages;
using BulletinBoard.Models.Notices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulletinBoard.Services.Notices.Contracts
{
    public interface INoticeService
    {
        List<NoticeModel> GetAllNotices(NoticeIndexModel model);
        void CreateNotice(NoticeCreateModel model, int currentUserId);
        int AddLike(int noticeId);
        NoticeEditModel GetNoticeById(in int noticeId);
        CommentModel AddComment(AddCommentRequestModel model, User user);
        IEnumerable<GalleryImageModel> UploadImages(AddGalleryImageModel model);
        SelectList GetCategoriesSelect();
        void EditNotice(NoticeEditModel model);
        NoticeCreateModel GetNoticeCreateModel();
        void Upper(int noticeId);
    }
}