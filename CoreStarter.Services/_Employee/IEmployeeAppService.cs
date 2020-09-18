using CoreStarter.Core.Core;
using CoreStarter.Services._Employee.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStarter.Services._Employee
{
    public interface IEmployeeAppService : IBaseCRUDAppService<long, EmployeeDto, EmployeeCreateDto, EmployeeEditDto>
    {

    }
}
