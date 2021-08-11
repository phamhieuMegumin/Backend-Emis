using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Emis.Core.Interfaces.Repository;
using MISA.Emis.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MISA.Emis.Web.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        #region Field
        IBaseRepository<T> _baseRepository;
        IBaseService<T> _baseService;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseRepository<T> baseRepository, IBaseService<T> baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion

        #region Methods
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var accountId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            var entities = _baseRepository.GetAll(Guid.Parse(accountId));
            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            return NoContent();
        }

        [Authorize]
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId)
        {
            var entity = _baseRepository.GetById(entityId);
            if (entity != null)
            {
                return Ok(entity);
            }
            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Insert(T entity)
        {
            var rowEffects = _baseService.Insert(entity);
            if(rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }

        [Authorize]
        [HttpPut("{entityId}")]
        public IActionResult Update(Guid entityId, T entity)
        {
            var rowEffects = _baseService.Update(entityId, entity);
            if(rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{entityId}")]

        public IActionResult Delete(Guid entityId)
        {
            var rowEffects = _baseRepository.Delete(entityId);
            if(rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }
        #endregion

    }
}
