using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.Models.Categories
{
    public class CategoryCreateModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "KeyWord cannot be empty")]
        public string Name { get; set; }
    }
}
