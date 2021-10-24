namespace Extensions.Repository.Models
{
    public class Pagination
    {
        public Pagination(int total, int count, int perPage, int currentPage, int totalPages)
        {
            Total = total;
            Count = count;
            PerPage = perPage;
            CurrentPage = currentPage;
            TotalPages = totalPages;
        }

        public int Total { get; }
        public int Count { get; }
        public int PerPage { get; }
        public int CurrentPage { get; }
        public int TotalPages { get; }
    }
}