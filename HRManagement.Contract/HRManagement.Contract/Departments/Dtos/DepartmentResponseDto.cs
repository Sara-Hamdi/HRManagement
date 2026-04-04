namespace HRManagement.Contract.Departments.Dtos
{
    public class DepartmentResponseDto
    {
        public required Guid Id { get; set; }
        public required string NameAr { get; set; }
        public required string NameEn { get; set; }
    }
}
