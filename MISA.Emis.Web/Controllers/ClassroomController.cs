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
        public ClassroomController( IBaseRepository<Classroom> baseRepository, IClassroomService classroomService):base(baseRepository, classroomService)
        {
            _classroomService = classroomService;
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
    }
}
