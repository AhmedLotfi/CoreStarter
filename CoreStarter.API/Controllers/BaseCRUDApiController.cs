using CoreStarter.Core.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreStarter.API.Controllers
{
    public class BaseCRUDApiController<IEntityAppService, TEntity, TPrimaryKey, TEntityDto, TEntityCreateDto, TEntityEditDto>
        : BaseApiController

        where IEntityAppService : IBaseCRUDAppService<TPrimaryKey, TEntityDto, TEntityCreateDto, TEntityEditDto>
        where TEntity : class
        where TEntityDto : new()
        where TEntityCreateDto : class
        where TEntityEditDto : class
    {
        private readonly IEntityAppService _entityAppService;

        public BaseCRUDApiController(IEntityAppService entityAppService)
        {
            _entityAppService = entityAppService;
        }

        [HttpGet]
        [Route(nameof(GetAllAsync))]
        public virtual async Task<ActionResult<IReadOnlyList<TEntityDto>>> GetAllAsync()
        {
            return Ok(await _entityAppService.GetAllAsync());
        }

        [HttpGet]
        [Route(nameof(GetByIdAsync))]
        public virtual async Task<ActionResult<TEntityDto>> GetByIdAsync(TPrimaryKey primaryKey)
        {
            return Ok(await _entityAppService.GetByIdAsync(primaryKey));
        }

        [HttpPost]
        [Route(nameof(InsertAsync))]
        public virtual async Task<ActionResult<TEntityDto>> InsertAsync(TEntityCreateDto entityCreateDto)
        {
            return await _entityAppService.InsertAsync(entityCreateDto);
        }

        [HttpPut]
        [Route(nameof(UpdateAsync))]
        public virtual async Task<ActionResult<TEntityDto>> UpdateAsync(TEntityEditDto entityEditDto)
        {
            return await _entityAppService.UpdateAsync(entityEditDto);
        }

        [HttpDelete]
        [Route(nameof(DeleteAsync))]
        public virtual async Task<bool> DeleteAsync(TPrimaryKey primaryKey)
        {
            return await _entityAppService.DeleteAsync(primaryKey);
        }
    }
}