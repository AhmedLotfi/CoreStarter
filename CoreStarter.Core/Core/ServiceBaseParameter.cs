using AutoMapper;
using CoreStarter.Infrastructure.Interfaces;

namespace CoreStarter.Core.Core
{
    public abstract class ServiceBaseParameter : IServiceBaseParameter
    {
        public IMapper Mapper { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public ServiceBaseParameter(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
    }
}
