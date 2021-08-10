using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Emis.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Emis.Web.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        #region Field
        IBaseRepository<T> _baseRepository;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _baseRepository.GetAll();
            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            return NoContent();
        }

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

        [HttpPost]
        public IActionResult Insert(T entity)
        {
            var rowEffects = _baseRepository.Insert(entity);
            if(rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }

        [HttpPut("{entityId}")]
        public IActionResult Update(Guid entityId, T entity)
        {
            var rowEffects = _baseRepository.Update(entityId, entity);
            if(rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }

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
