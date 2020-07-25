using System;
using AutoMapper;
using BulletinBoard.DAL.Entities;
using BulletinBoard.Models.Categories;
using BulletinBoard.Models.Comments;
using BulletinBoard.Models.GalleryImages;
using BulletinBoard.Models.Notices;
using BulletinBoard.Models.Products;

namespace BulletinBoard
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateCategoryToCategoryModelMap();
            CreateCategoryCreateModelToCategory();

            CreateNoticeToNoticeModelMap();
            CreateGalleryImageToModel();
            CreateAddCommentRequestToCommentMap();
            CreateCommentToCommentModelMap();
            CreateRecordCreateModelToRecord();
        }


        private void CreateGalleryImageToModel()
        {
            CreateMap<GalleryImage, GalleryImageModel>();
        }

        private void CreateAddCommentRequestToCommentMap()
        {
            CreateMap<AddCommentRequestModel, Comment>()
                .ForMember(target => target.Content,
                    src => src.MapFrom(p => p.Comment));
        }

        private void CreateCommentToCommentModelMap()
        {
            CreateMap<Comment, CommentModel>()
                .ForMember(target => target.CreatedOn,
                    src => src.MapFrom(p => p.CreatedOn.ToString("D")))
                .ForMember(target => target.AuthorName,
                    src => src.MapFrom(p => p.Author.UserName));
        }

        private void CreateCategoryCreateModelToCategory()
        {
            CreateMap<CategoryCreateModel, Category>();
        }

        private void CreateCategoryToCategoryModelMap()
        {
            CreateMap<Category, CategoryModel>();
        }

        public void CreateNoticeToNoticeModelMap()
        {
            CreateMap<Notice, NoticeModel>()
                .ForMember(target => target.CreatedOn,
                    src => src.MapFrom(p => p.CreatedOn.ToString("D")))
                .ForMember(target => target.Images,
                    src => src.MapFrom(p => p.ProductImages))
                .ForMember(target => target.Author,
                    src => src.MapFrom(p => p.User.UserName))
                .ForMember(target => target.Description,
                    src => src.MapFrom(p => p.Description))
                .ForMember(target => target.Category,
                    src => src.MapFrom(p => p.Category));
        }

        public void CreateRecordCreateModelToRecord()
        {
            CreateMap<NoticeCreateModel, Notice>()
                .ForMember(target => target.CreatedOn,
                    src => src.MapFrom(p => DateTime.Now))
                .ForMember(target => target.Image,
                    src => src.Ignore());
        }

        private void CreateUniversalMap<From, To>()
        {
            CreateMap<From, To>();
            CreateMap<To, From>();
        }
    }
}
