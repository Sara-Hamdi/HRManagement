using MediatR;

namespace HRManagement.Application.Features.Departments.CommandsHandlers.Commands
{
    public class CreateDepartmentCommand : IRequest<Guid>
    {
        public required string NameAr { get; set; }
        public required string NameEn { get; set; }
    }
}
