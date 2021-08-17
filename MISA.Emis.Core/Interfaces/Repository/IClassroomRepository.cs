using MISA.Emis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Interfaces.Repository
{
    public interface IClassroomRepository:IBaseRepository<Classroom>
    {
        /// <summary>
        /// Lấy ID class mới nhất được thêm vào
        /// </summary>
        /// <returns>
        /// ID class mới được thêm vào
        /// </returns>
        /// CreatedBy : PQHieu(15/08/2021)
        Guid GetNewestClassroomId();

        /// <summary>
        /// Kiểm tra mã lớp học đã tồn tại chưa
        /// </summary>
        /// <returns>
        /// true - Mã lớp đã tồn tại
        /// falsw - Mã lớp chưa tồn tại
        /// </returns>
        /// CreatedBy : PQHieu(17/08/2021)
        bool CheckClassroomCodeExist(string classroomCode);
    }
}
