using System;
using System.Linq;
using System.Threading.Tasks;
using BulletinBoard.DAL.Entities;
using BulletinBoard.Models.Comments;
using BulletinBoard.Models.GalleryImages;
using BulletinBoard.Models.Notices;
using BulletinBoard.Models.Products;
using BulletinBoard.Services.Notices.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BulletinBoard.Controllers
{
    public class NoticeController : Controller
    {
        private readonly INoticeService _noticeService;
        private readonly UserManager<User> _userManager;

        public NoticeController(INoticeService noticeService, UserManager<User> userManager)
        {
            _noticeService = noticeService;
            _userManager = userManager;
        }

        public IActionResult Index(NoticeIndexModel model)
        {
            try
            {
                var recordModels = _noticeService.GetAllNotices(model).OrderByDescending(p=>p.CreatedOn);

                model.Notices = recordModels.ToList();

                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Authorize]
        public IActionResult Create()
        {
            var model = _noticeService.GetNoticeCreateModel();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRecord(NoticeCreateModel model)
        {
            try
            {
                User currentUser = await _userManager.GetUserAsync(User);

                _noticeService.CreateNotice(model, currentUser.Id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Details(int noticeId)
        {
            var recordModel = _noticeService.GetNoticeById(noticeId);

            return View(recordModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Like(int noticeId)
        {
            _noticeService.AddLike(noticeId);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult LikeAjax(int noticeId)
        {
            try
            {
                var likes = _noticeService.AddLike(noticeId);

                return Ok(likes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentRequestModel model)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var commentModel = _noticeService.AddComment(model, currentUser);

                return Ok(commentModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Upload(AddGalleryImageModel model)
        {
            try
            {
                _noticeService.UploadImages(model);
                return RedirectToAction("Details", new { noticeId = model.NoticeId });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult UploadAjax(int noticeId)
        {
            try
            {
                AddGalleryImageModel model = new AddGalleryImageModel()
                {
                    NoticeId = noticeId,
                    Images = Request.Form.Files
                };

                var imageModels = _noticeService.UploadImages(model);

                return Ok(imageModels.ToList());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.BadRequestMessage = "Notice id cannot be NULL";
                return View("BadRequest");
            }

            var noticeEditModel = _noticeService.GetNoticeById(id.Value);

            return View(noticeEditModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult EditProduct(NoticeEditModel model)
        {
            try
            {
                _noticeService.EditNotice(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Upper(int noticeId)
        {

            _noticeService.Upper(noticeId);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpperAjax(int noticeId)
        {
            try
            {
                _noticeService.Upper(noticeId);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}