namespace HRManagement.Application.Baeses
{
    public class PaginatedResult<T>
    {
        public int TotalCount { get; set; }
        public List<T> List { get; set; }

        public PaginatedResult(List<T> list, int totalCount)
        {
            TotalCount = totalCount;
            List = list;
        }
    }
}
