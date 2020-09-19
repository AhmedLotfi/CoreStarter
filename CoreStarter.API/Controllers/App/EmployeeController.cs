using CoreStarter.EFCore.Entites;
using CoreStarter.Services._Employee;
using CoreStarter.Services._Employee.dto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreStarter.API.Controllers.App
{
    /// <summary>
    /// EmployeeController
    /// </summary>
    public class EmployeeController : BaseCRUDApiController<IEmployeeAppService, Employee, long, EmployeeDto, EmployeeCreateDto, EmployeeEditDto>
    {
        public EmployeeController(IEmployeeAppService entityAppService) : base(entityAppService)
        {
        }
    }
}