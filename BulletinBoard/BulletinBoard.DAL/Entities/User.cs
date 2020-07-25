using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BulletinBoard.DAL.Entities
{
    public class User: IdentityUser<int>, IEntity
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AvatarUrl { get; set; }

        public ICollection<Notice> Notices { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}