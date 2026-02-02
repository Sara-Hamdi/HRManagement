namespace HRManagement.Application.Contracts.Departments.Dtos.ResponseDtos
{
    public class DepartmentResponseDto
    {
        public required Guid Id { get; set; }
        public required string NameAr { get; set; }
        public required string NameEn { get; set; }
    }
}
