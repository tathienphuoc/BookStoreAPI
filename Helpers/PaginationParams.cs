namespace BookStoreAPI.Helpers
{
    public class PaginationParams
    {
        private const int MaxPageSize = 50;
        public int pageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public int pageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize)? MaxPageSize : value;
            // Set pagesize: neu value > maxpagesize thi  pagesize = maxpagesize nguoc lai thi = value
        }
    }
}