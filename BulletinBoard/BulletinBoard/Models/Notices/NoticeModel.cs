using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BulletinBoard.DAL.Entities;
using BulletinBoard.Models.Comments;
using BulletinBoard.Models.GalleryImages;

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
        public int UserId { get; set; }
        [Display(Name = "Автор")]
        public User User { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Категория")]
        public Category Category { get; set; }
        [Display(Name = "Дата публикации")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Лайки")]
        public int Likes { get; set; }
        public byte[] Image { get; set; }
        public string ImagePath { get; set; }
        public RecordImageType RecordImageType { get; set; }
        public List<CommentsModel> Comments { get; set; }
        public List<GalleryImageModel> Images { get; set; }
    }
}