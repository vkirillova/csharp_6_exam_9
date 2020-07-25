using System.Collections.Generic;
using BulletinBoard.Models.Categories;

namespace BulletinBoard.Views.Categories.Contracts
{
    public interface ICategoryService
    {
        List<CategoryModel> Categories(CategoryFilterModel model);
        CategoryCreateModel GetCategoryCreateModel();
        void CreateCategory(CategoryCreateModel model);
    }
}
