using AutoMapper;
using CoreStarter.Infrastructure.Interfaces;

namespace CoreStarter.Core.Core
{
    public interface IServiceBaseParameter
    {
        IMapper Mapper { get; set; }
        IUnitOfWork UnitOfWork { get; set; }
    }
}
