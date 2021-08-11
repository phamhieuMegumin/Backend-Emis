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
    
    public class ClassroomController : BaseEntityController<Classroom>
    {
        public ClassroomController(IBaseRepository<Classroom> baseRepository, IBaseService<Classroom> baseService):base(baseRepository, baseService)
        {

        }
    }
}
