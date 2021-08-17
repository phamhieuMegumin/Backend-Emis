using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Emis.Core.Entities;
using MISA.Emis.Core.Interfaces.Repository;
using MISA.Emis.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MISA.Emis.Web.Controllers
{
    
    public class ClassroomController : BaseEntityController<Classroom>
    {
        IClassroomService _classroomService;
        IBaseRepository<Classroom> _baseRepository;
        public ClassroomController( IBaseRepository<Classroom> baseRepository, IClassroomService classroomService):base(baseRepository, classroomService)
        {
            _classroomService = classroomService;
            _baseRepository = baseRepository;
        }
        public override IActionResult Insert(Classroom classroom)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var accountId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            var rowEffects = _classroomService.Insert(Guid.Parse(accountId), classroom);
            if (rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }

        public override IActionResult GetById(Guid entityId)
        {
            var classroom = _classroomService.GetClassroomById(entityId);
            if (classroom != null)
            {
                return Ok(classroom);
            }
            return NoContent();
        }

        public override IActionResult Update(Guid entityId, Classroom entity)
        {
            var rowEffects = _baseRepository.UpdateWithoutAccount(entityId, entity);
            if(rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }
        [HttpGet("TestGetCode")]
        public IActionResult GetCode()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var newString = new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return Ok(newString);
        }
    }
}
