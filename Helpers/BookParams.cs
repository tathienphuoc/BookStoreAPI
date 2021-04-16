namespace BookStoreAPI.Helpers
{
    public class BookParams : PaginationParams
    {
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public string TitleSearch { get; set; } ="";
    }
}