using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Emis.Core.Entities;
using MISA.Emis.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Emis.Web.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        IBaseRepository<Grade> _baseRepository;
        public GradeController(IBaseRepository<Grade> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var grades = _baseRepository.GetAllWithoutAccount();
            if(grades.Count() > 0)
            {
                return Ok(grades);
            }
            return NoContent();
        }
    }
}
