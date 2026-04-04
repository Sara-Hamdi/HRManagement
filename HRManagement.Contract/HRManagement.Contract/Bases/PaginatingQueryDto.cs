using static HRManagement.Shared.Enums;

namespace HRManagement.Contract.Baeses
{
    public class PaginatingQueryDto
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public SortingDirection SortingDirection { get; set; }
        public string? SearchKey { get; set; }
    }
}
