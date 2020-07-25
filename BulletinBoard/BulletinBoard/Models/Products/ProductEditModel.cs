using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulletinBoard.Models.Products
{
    public class ProductEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string BrandId { get; set; }
        public decimal Price { get; set; }
        public SelectList CategoriesSelect { get; set; }
        public SelectList BrandsSelect { get; set; }
    }
}
