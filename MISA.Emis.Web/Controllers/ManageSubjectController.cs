using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Emis.Core.Entities;
using MISA.Emis.Core.Interfaces.Repository;
using MISA.Emis.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Emis.Web.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class ManageSubjectController : BaseEntityController<ManageSubject>
    {
        IManageSubjectService _manageSubjectService;
        public ManageSubjectController(IBaseRepository<ManageSubject> baseRepository, IManageSubjectService manageSubjectService) : base(baseRepository, manageSubjectService)
        {
            _manageSubjectService = manageSubjectService;
        }
        
        [HttpPost("InsertList")]
        public IActionResult InsertList(List<ManageSubject> listSubject)
        {
            var rowEffects = _manageSubjectService.InsertList(listSubject);
            if(rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }
        [HttpPut("UpdateList/{classroomId}")]
        public IActionResult UpdateList(Guid classroomId, List<ManageSubject> listSubject)
        {
            var rowEffects = _manageSubjectService.UpdateManage(classroomId, listSubject);
            if(rowEffects > 0)
            {
                return Ok();
            }
            return NoContent();
        }
    }
}
