using System;

namespace Framework.Core
{
    public class UserParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize;}
            set { pageSize = (value > MaxPageSize)? MaxPageSize : value; }
        }

        public int UserId { get; set; }

        public int Count { get; set; }

        public int TotalPages => (int)Math.Ceiling(Count / (double)pageSize);

        public string OrderBy { get; set; }

        public string OrderByType { get; set; }

    }



}