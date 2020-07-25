using System.IO;
using BulletinBoard.DAL.Entities;
using BulletinBoard.Services.GalleryImages.Contracts;
using Microsoft.AspNetCore.Http;

namespace BulletinBoard.Services.GalleryImages
{
    public class DbFilesSaver : IFileSaver
    {
        public void SaveFile(Notice notice, IFormFile formFile)
        {
            notice.Image = GetImageBytes(formFile);
            notice.RecordImageType = RecordImageType.Db;
        }

        public byte[] GetImageBytes(IFormFile formFile)
        {
            using (var binaryReader = new BinaryReader(formFile.OpenReadStream()))
            {
                return binaryReader.ReadBytes((int)formFile.Length);
            }
        }
    }
}
