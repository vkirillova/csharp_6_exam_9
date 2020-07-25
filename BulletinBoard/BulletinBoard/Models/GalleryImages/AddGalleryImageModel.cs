using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BulletinBoard.Models.GalleryImages
{
    public class AddGalleryImageModel
    {
        [Required]
        public int NoticeId { get; set; }

        public IFormFileCollection Images { get; set; }
    }
}
