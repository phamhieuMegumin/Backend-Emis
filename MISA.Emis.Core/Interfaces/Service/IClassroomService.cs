using MISA.Emis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Interfaces.Service
{
    public interface IClassroomService:IBaseService<Classroom>
    {
        /// <summary>
        /// Lấy thông tin lớp học theo Id
        /// </summary>
        /// <param name="classroomId">ID lớp học</param>
        /// <returns>
        /// Thông tin lớp học
        /// </returns>
        /// CreatedBy : PQHieu(16/08/2021)
        Classroom GetClassroomById(Guid classroomId);
    }
}
