using CoreStarter.Core.Core;
using CoreStarter.Services._Employee.dto;

namespace CoreStarter.Services._Employee
{
    public interface IEmployeeAppService : IBaseCRUDAppService<long, EmployeeDto, EmployeeCreateDto, EmployeeEditDto>
    {

    }
}
