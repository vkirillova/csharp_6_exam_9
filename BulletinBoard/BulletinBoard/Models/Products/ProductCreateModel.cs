using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulletinBoard.Models.Products
{
    public class ProductCreateModel
    {
        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Product name cannot be null")]
        public string Name { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category cannot be null")]
        public int CategoryId { get; set; }

        [Display(Name = "Brand")]
        public int? BrandId { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price cannot be null")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Price cannot be negative")]
        public decimal Price { get; set; }
        public SelectList CategoriesSelect { get; set; }
        public SelectList BrandsSelect { get; set; }
    }
}
