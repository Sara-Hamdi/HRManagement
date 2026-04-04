using HRManagement.Application.Features.Departments.CommandsHandlers.Commands;
using HRManagement.Domain.Aggregates.DepartmentAggregate;
using MediatR;

namespace HRManagement.Application.Features.Departments.CommandsHandlers.Handlers
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Guid>
    {
        private readonly DepartmentManager _departmentManager;
        public CreateDepartmentCommandHandler(DepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {

            var departmentId = await _departmentManager.CreateAsync(request.NameAr, request.NameEn);
            return departmentId;
        }
    }
}
