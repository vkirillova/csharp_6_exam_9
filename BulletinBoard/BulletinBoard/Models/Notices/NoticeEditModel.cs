using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulletinBoard.Models.Notices
{
    public class NoticeEditModel
    {
        public int Id { get; set; }
        [Display(Name = "Заголовок")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Изображение")]
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Категория")]
        public SelectList CategoriesSelect { get; set; }
    }
}