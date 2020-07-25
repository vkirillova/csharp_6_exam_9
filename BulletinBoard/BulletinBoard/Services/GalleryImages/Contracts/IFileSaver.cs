using BulletinBoard.DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace BulletinBoard.Services.GalleryImages.Contracts
{
    public interface IFileSaver
    {
        void SaveFile(Notice notice, IFormFile formFile);
    }
}