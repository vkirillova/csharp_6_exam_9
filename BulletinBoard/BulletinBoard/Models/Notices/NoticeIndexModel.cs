using System;
using System.Collections.Generic;
using BulletinBoard.Models.GalleryImages;

namespace BulletinBoard.Models.Notices
{
    public class NoticeIndexModel
    {
        public string Author { get; set; }
        public string SearchKey { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<NoticeModel> Notices { get; set; }
        public int? Page { get; set; }
        public PagingModel PagingModel { get; set; }
    }
}