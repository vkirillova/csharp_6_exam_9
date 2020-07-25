using System;
using System.Collections.Generic;

namespace BulletinBoard.DAL.Entities
{
    public class Notice: IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Likes { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public string ImagePath { get; set; }

        public RecordImageType RecordImageType { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<GalleryImage> ProductImages { get; set; }
    }
}