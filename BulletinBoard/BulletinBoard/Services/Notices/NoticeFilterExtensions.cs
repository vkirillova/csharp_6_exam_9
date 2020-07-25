using System;
using System.Collections.Generic;
using System.Linq;
using BulletinBoard.DAL.DbContext;
using BulletinBoard.DAL.Entities;

namespace BulletinBoard.Services.Notices
{
    public static class NoticeFilterExtensions
    {
        // method chaining
        public static IEnumerable<Notice> ByPriceFrom(this IEnumerable<DAL.Entities.Notice> notices, decimal? priceFrom)
        {
            if (priceFrom.HasValue)
                return notices.Where(p => p.Price >= priceFrom.Value);
            return notices;
        }

        public static IEnumerable<Notice> ByPriceTo(this IEnumerable<DAL.Entities.Notice> notices, decimal? priceTo)
        {
            if (priceTo.HasValue)
                return notices.Where(p => p.Price <= priceTo.Value);
            return notices;
        }

        public static IEnumerable<Notice> SearchByKeyWord(this IEnumerable<Notice> notices, string keyWord)
        {
            if (!string.IsNullOrWhiteSpace(keyWord))
                notices = notices.Where(r => r.Title.Contains(keyWord) || r.Description.Contains(keyWord));

            return notices;
        }

        public static IEnumerable<Notice> ByCategoryId(this IEnumerable<Notice> notices, UnitOfWork unitOfWork, int? categoryId)
        {
            if (categoryId.HasValue)
            {
                var category = unitOfWork.Categories.GetById(categoryId.Value);
                if (category == null)
                    throw new ArgumentOutOfRangeException(
                        nameof(categoryId),
                        $"No category with Id {categoryId}");
                return notices.Where(p => p.CategoryId == categoryId);
            }

            return notices;
        }
    }
}