using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BulletinBoard.DAL.Entities;
using BulletinBoard.Models.Comments;
using BulletinBoard.Models.GalleryImages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulletinBoard.Models.Notices
{
    public class NoticeModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Заголовок")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        public SelectList Category { get; set; }
        [Display(Name = "Дата публикации")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Лайки")]
        public int Likes { get; set; }
        public byte[] Image { get; set; }
        public string ImagePath { get; set; }

        public RecordImageType RecordImageType { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<GalleryImageModel> Images { get; set; }
    }
}