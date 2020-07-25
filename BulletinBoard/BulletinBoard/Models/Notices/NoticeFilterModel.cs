using System.Collections.Generic;
using BulletinBoard.Models.Products;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulletinBoard.Models.Notices
{
    public class NoticeFilterModel
    {
        public string KeyWord { get; set; }
        public int? CategoryId { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public List<NoticeModel> Notices { get; set; }
        public SelectList CategoriesSelect { get; set; }
    }
}