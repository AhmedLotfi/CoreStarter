using CoreStarter.Core.Core;
using CoreStarter.EFCore.Entites;
using CoreStarter.Services._Employee.dto;

namespace CoreStarter.Services._Employee
{
    public class EmployeeAppService : BaseCRUDAppService<Employee, long, EmployeeDto, EmployeeCreateDto, EmployeeEditDto>, IEmployeeAppService
    {
        public EmployeeAppService(IServiceBaseParameter serviceBaseParameter) : base(serviceBaseParameter)
        {
        }
    }
}
