using MediatR;

namespace HRManagement.Application.Contracts.Departments.Dtos.RequestDtos
{
    public class CreateDepartmentRequestDto : IRequest<Guid>
    {
        public required string NameAr { get; set; }
        public required string NameEn { get; set; }
    }
}
