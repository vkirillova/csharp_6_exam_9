using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.Models.Comments
{
    public class CommentModel
    {
        public int Id { get; set; }

        [Display(Name = "Дата публикации")]
        public string CreatedOn { get; set; }

        [Display(Name = "Автор")]
        public string AuthorName { get; set; }

        [Display(Name = "Содержание")]
        public string Content { get; set; }
    }
}