using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BulletinBoard.Models.Comments
{
    public class AddCommentRequestModel
    {
        [Required]
        [JsonProperty(propertyName: "comment")]
        public string Comment { get; set; }

        [Required]
        [JsonProperty(propertyName: "noticeId")]
        public int NoticeId { get; set; }
    }
}