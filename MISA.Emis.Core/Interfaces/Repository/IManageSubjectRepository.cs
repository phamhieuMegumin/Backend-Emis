using MISA.Emis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Interfaces.Repository
{
    public interface IManageSubjectRepository:IBaseRepository<ManageSubject>
    {
       /// <summary>
       /// Lấy danh sách quản lý môn học qua ID lớp học
       /// </summary>
       /// <param name="classId">ID lớp học</param>
       /// <returns>
       /// Danh sách các bản ghi có ID lớp học cần tìm
       /// </returns>
       /// CreatedBy: PQHieu(16/08/2021)
        IEnumerable<ManageSubject> GetManageSubjectById(Guid classId);
    }
}
