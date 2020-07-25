using System;
using BulletinBoard.Models.Products;
using BulletinBoard.Services.Products.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BulletinBoard.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            if (productService == null)
                throw new ArgumentNullException(nameof(productService));

            _productService = productService;
        }

        [Route("Search/{name?}/{categoryId?}/{brandId?}/{priceFrom?}/{priceTo?}")]
        public IActionResult Index(ProductFilterModel model)
        {
            try
            {
                var products = _productService.SearchProducts(model);

                model.Products = products;
                model.CategoriesSelect = _productService.GetCategoriesSelect();
                model.BrandsSelect = _productService.GetBrandsSelect();

                return View(model);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ViewBag.BadRequestMessage = ex.Message;
                return View("BadRequest");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public IActionResult Create()
        {
            var model = _productService.GetProductCreateModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateModel model)
        {
            try
            {
                _productService.CreateProduct(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("Edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.BadRequestMessage = "Product id cannot be NULL";
                return View("BadRequest");
            }

            var productEditModel = _productService.GetProductById(id.Value);

            return View(productEditModel);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductEditModel model)
        {
            try
            {
                _productService.EditProduct(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}