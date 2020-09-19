using AutoMapper;
using CoreStarter.EFCore.Entites;
using CoreStarter.Services._Employee.dto;

namespace CoreStarter.Services.__MapperProfiles
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeEditDto, Employee>();
        }
    }
}
