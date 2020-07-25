using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BulletinBoard.DAL.Entities;
using BulletinBoard.Models.GalleryImages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulletinBoard.Models.Notices
{
    public class NoticeCreateModel
    {
        [Required(ErrorMessage = "Нужен заголовок")]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Вы уверены, что хотите отдать бесплатно свой товар?")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Вы уверены, что хотите отдать товар и ещё доплатить за него?")]
        public decimal Price { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Выберите категорию")]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        public SelectList CategoriesSelect { get; set; }

        [Required(ErrorMessage = "Оставьте свои контакты, чтобы с Вами могли связаться")]
        public int UserId { get; set; }
        [Display(Name = "Автор")]
        public User User { get; set; }

        [Display(Name = "Изображение")]
        public List<GalleryImageModel> Images { get; set; }
        public IFormFile Image { get; set; }
        public IFormFileCollection ImgsCollection { get; set; }
    }
}