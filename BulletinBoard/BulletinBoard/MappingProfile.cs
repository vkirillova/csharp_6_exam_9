using AutoMapper;
using BulletinBoard.DAL.Entities;
using BulletinBoard.Models.Categories;
using BulletinBoard.Models.Products;

namespace BulletinBoard
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateProductToProductModelMap();
            CreateProductCreateModelToProduct();
            CreateProductToProductEditModel();
            CreateProductEditModelToProduct();

            CreateCategoryToCategoryModelMap();
            CreateCategoryCreateModelToCategory();
        }

        private void CreateProductToProductModelMap()
        {
            CreateMap<Product, ProductModel>()
                .ForMember(target => target.CategoryName,
                    src => src.MapFrom(p => p.Category.Name));
        }

        private void CreateProductCreateModelToProduct()
        {
            CreateMap<ProductCreateModel, Product>();
        }

        private void CreateProductToProductEditModel()
        {
            CreateMap<Product, ProductEditModel>();
        }

        private void CreateProductEditModelToProduct()
        {
            CreateMap<ProductEditModel, Product>();
        }

        //private void CreateOrderCreateModelToOrderMap()
        //{
        //    CreateMap<OrderCreateModel, Order>();
        //}

        //private void CreateOrderToOrderIndexModelMap()
        //{
        //    CreateMap<Order, OrderIndexModel>()
        //        .ForMember(target => target.Price,
        //        src => src.MapFrom(p => p.Product.Price))
        //        .ForMember(target => target.ProductName,
        //            src => src.MapFrom(p => $"{p.Product.Brand.KeyWord} {p.Product.KeyWord}"))
        //        .ForMember(target => target.OrderCreatedOn,
        //            src => src.MapFrom(p => p.CreatedOn))
        //        .ForMember(target => target.OrderSum,
        //            src => src.MapFrom(p => p.Sum))
        //        .ForMember(target => target.CustomerName,
        //            src => src.MapFrom(p => p.Customer.KeyWord)); ;
        //}

        private void CreateCategoryCreateModelToCategory()
        {
            CreateMap<CategoryCreateModel, Category>();
        }

        private void CreateCategoryToCategoryModelMap()
        {
            CreateMap<Category, CategoryModel>();
        }
    }
}
