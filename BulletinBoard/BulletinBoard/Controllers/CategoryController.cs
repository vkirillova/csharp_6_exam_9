using System;
using BulletinBoard.Models.Categories;
using BulletinBoard.Views.Categories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BulletinBoard.Controllers
{
    public class CategoryController: Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            if (categoryService == null)
                throw new ArgumentNullException(nameof(categoryService));
            _categoryService = categoryService;
        }

        public IActionResult Index(CategoryFilterModel model)
        {
            var models = _categoryService.Categories(model);
            return View(models);
        }

        public IActionResult Create()
        {
            var model = _categoryService.GetCategoryCreateModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateModel model)
        {
            try
            {
                _categoryService.CreateCategory(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
