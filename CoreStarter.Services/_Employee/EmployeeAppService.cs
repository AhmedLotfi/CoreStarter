using AutoMapper;
using CoreStarter.Core.Core;
using CoreStarter.EFCore.Entites;
using CoreStarter.Infrastructure.Interfaces;
using CoreStarter.Services._Employee.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreStarter.Services._Employee
{
    public class EmployeeAppService : BaseCRUDAppService<Employee, long, EmployeeDto, EmployeeCreateDto, Employee>, IEmployeeAppService
    {
        public EmployeeAppService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
