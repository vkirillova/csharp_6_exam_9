using System;
using System.IO;
using BulletinBoard.DAL.Entities;
using BulletinBoard.Services.GalleryImages.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BulletinBoard.Services.GalleryImages
{
    public class DiskFileSaver : IFileSaver
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public DiskFileSaver(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public void SaveFile(Notice notice, IFormFile formFile)
        {
            var fileFullName = formFile.FileName;
            var fileId = Guid.NewGuid();
            var fileName = Path.GetFileNameWithoutExtension(fileFullName);
            var fileExtension = Path.GetExtension(fileFullName);

            string filePath = $"/files/{fileName}-{fileId}{fileExtension}";
            notice.ImagePath = filePath;
            //notice.RecordImageType = RecordImageType.Disk;
            using (var fileStream = new FileStream(_hostEnvironment.WebRootPath + filePath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
        }
    }
}