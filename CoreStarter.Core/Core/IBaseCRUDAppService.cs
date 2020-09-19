using CoreStarter.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreStarter.Core.Core
{
    public interface IBaseCRUDAppService<TEntityPrimaryKey, TEntityDto, TCreateEntityDto, TEditEntityDto>
        where TEntityDto : new()
        where TCreateEntityDto : class
        where TEditEntityDto : class
    {
        Task<IReadOnlyList<TEntityDto>> GetAllAsync();

        Task<TEntityDto> GetByIdAsync(TEntityPrimaryKey entityPrimaryKey);

        Task<TEntityDto> InsertAsync(TCreateEntityDto createEntityDto);

        Task<TEntityDto> UpdateAsync(TEditEntityDto editEntityDto);

        Task<bool> DeleteAsync(TEntityPrimaryKey entityPrimaryKey);
    }
}
