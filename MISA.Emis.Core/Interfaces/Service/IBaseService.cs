using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Interfaces.Service
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="entity">Bả ghi cần thêm mới</param>
        /// <returns>Số lượng bản ghi được thêm thành công</returns>
        /// CreatedBy : PQHieu(10/08/2021)
        int Insert(T entity);

        /// <summary>
        /// Cập nhật thông tin bản ghi theo ID
        /// </summary>
        /// <param name="entityId">ID của bản ghi cần cập nhật</param>
        /// <param name="entity">Bản ghi mới</param>
        /// <returns>Số lượng bản ghi cập nhật thành công</returns>
        /// CreatedBy : PQHieu(10/08/2021)
        int Update(Guid entityId, T entity);
    }
}
