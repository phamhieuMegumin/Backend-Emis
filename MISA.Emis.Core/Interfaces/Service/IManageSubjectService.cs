using MISA.Emis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Interfaces.Service
{
    public interface IManageSubjectService:IBaseService<ManageSubject>
    {
        /// <summary>
        /// Thêm mới 1 danh sách bản ghi
        /// </summary>
        /// <param name="listEntity">Danh sách bản ghi</param>
        /// <returns></returns>
        int InsertList(List<ManageSubject> listEntity);

        /// <summary>
        /// Cập nhật quản lý môn học
        /// - Xóa danh sách môn học của lớp theo ID
        /// - Thêm mới danh sách môn học mới của lớp đó
        /// </summary>
        /// <param name="classroomId">ID của lớp được chỉnh sửa</param>
        /// <param name="listEntity">Danh sách môn học mới</param>
        /// <returns>
        /// Số lượng bản ghi được thêm mới
        /// </returns>
        /// CreatedBy : PQHieu(16/08/2021)
        int UpdateManage(Guid classroomId, List<ManageSubject> listEntity);
    }
}
