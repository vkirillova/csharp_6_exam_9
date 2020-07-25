﻿using System;

namespace BulletinBoard.Models.GalleryImages
{
    public class PagingModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public PagingModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;
    }
}
