using System;
using System.Collections.Generic;
using BulletinBoard.Models.GalleryImages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulletinBoard.Models.Notices
{
    public class NoticeIndexModel
    {
        public string Author { get; set; }
        public string SearchKey { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }

        public int? CategoryId { get; set; }
        public SelectList CategoriesSelect { get; set; }
        public List<NoticeModel> Notices { get; set; }
        public int? Page { get; set; }
        public PagingModel PagingModel { get; set; }
        public byte[] Image { get; set; }
    }
}