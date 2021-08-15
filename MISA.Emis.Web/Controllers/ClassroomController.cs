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
        IBaseService<Classroom> _baseService;
        public ClassroomController( IBaseRepository<Classroom> baseRepository, IBaseService<Classroom> baseService):base(baseRepository, baseService)
        {
            _baseService = baseService;
        }
        public override IActionResult Insert(Classroom classroom)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var accountId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            var rowEffects = _baseService.Insert(Guid.Parse(accountId), classroom);
            if (rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }
    }
}
