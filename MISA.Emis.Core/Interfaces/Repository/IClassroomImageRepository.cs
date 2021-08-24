using MISA.Emis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Interfaces.Repository
{
    public interface IClassroomImageRepository:IBaseRepository<ClassroomImage>
    {
        /// <summary>
        /// Lấy hình ảnh lớp học
        /// </summary>
        /// <param name="classId">ID lớp học</param>
        /// <returns>Thông tin hình ảnh</returns>
        /// CreatedBy : PQHieu(23/08/2021)
        ClassroomImage GetImageUrl(Guid classId);

        /// <summary>
        /// Cập nhật ảnh lớp học
        /// </summary>
        /// <param name="classId">ID lớp học</param>
        /// <param name="classroomImage">Hình ảnh lớp học mới</param>
        /// <returns>Số lượng bản ghi được cập nhật</returns>
        /// CreatedBy : PQHieu(23/08/2021)
        int Update(ClassroomImage classroomImage);
    }
}
