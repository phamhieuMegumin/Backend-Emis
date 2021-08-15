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
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        IBaseRepository<Subject> _baseRepository;
        public SubjectController(IBaseRepository<Subject> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var subjects = _baseRepository.GetAllWithoutAccount();
            if (subjects.Count() > 0)
            {
                return Ok(subjects);
            }
            return NoContent();
        }
    }
}
