using System;

namespace BulletinBoard.DAL.Entities
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public int NoticeId { get; set; }
        public Notice Notice { get; set; }
    }
}
