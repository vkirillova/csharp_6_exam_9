using System;
using System.Collections.Generic;
using AutoMapper;
using BulletinBoard.DAL.DbContext.Contracts;
using BulletinBoard.DAL.Entities;
using BulletinBoard.Models.Categories;
using BulletinBoard.Views.Categories.Contracts;

namespace BulletinBoard.Views.Categories
{
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public CategoryService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public CategoryCreateModel GetCategoryCreateModel()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return new CategoryCreateModel();
            }
        }

        public void CreateCategory(CategoryCreateModel model)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var category = Mapper.Map<Category>(model);

                unitOfWork.Categories.Create(category);
            }
        }

        public List<CategoryModel> Categories(CategoryFilterModel model)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                IEnumerable<Category> categories = unitOfWork.Categories.GetAll();
                List<CategoryModel> categoryModels = Mapper.Map<List<CategoryModel>>(categories);

                return categoryModels;
            }
        }

    }
}
