using System.Collections.Generic;
using BulletinBoard.DAL.Entities;
using BulletinBoard.Models.Comments;
using BulletinBoard.Models.GalleryImages;
using BulletinBoard.Models.Notices;

namespace BulletinBoard.Services.Notices.Contracts
{
    public interface INoticeService
    {
        List<NoticeModel> GetAllNotices(NoticeIndexModel model);
        void CreateNotice(NoticeCreateModel model, int currentUserId);
        int AddLike(int noticeId);
        NoticeModel GetNoticeById(in int noticeId);
        CommentsModel AddComment(AddCommentRequestModel model, User user);
        IEnumerable<GalleryImageModel> UploadImages(AddGalleryImageModel model);
    }
}