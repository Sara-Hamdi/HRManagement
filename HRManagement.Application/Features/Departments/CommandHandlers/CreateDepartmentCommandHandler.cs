using HRManagement.Application.Contracts.Departments.Dtos.RequestDtos;
using HRManagement.Domain.Aggregates.DepartmentAggregate;
using MediatR;

namespace HRManagement.Application.Features.Departments.CommandHandlers
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentRequestDto, Guid>
    {
        private readonly DepartmentManager _departmentManager;
        public CreateDepartmentCommandHandler(DepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        public async Task<Guid> Handle(CreateDepartmentRequestDto request, CancellationToken cancellationToken)
        {

            var departmentId = await _departmentManager.CreateAsync(request.NameAr, request.NameEn);
            return departmentId;
        }
    }
}
