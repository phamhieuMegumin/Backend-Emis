using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy danh sách tất cả bản ghi 
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy : PQHIEU(11/06/2021)
        IEnumerable<T> GetAll(Guid accountId);

        

        /// <summary>
        /// Lấy danh sách tất cả bản ghi 
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy : PQHIEU(11/06/2021)
        IEnumerable<T> GetAllWithoutAccount();

        /// <summary>
        /// Lấy bản ghi theo ID
        /// </summary>
        /// <param name="entityId">ID cảu bản ghi muốn lấy</param>
        /// <returns>Bản ghi có ID cần lấy</returns>
        /// CreatedBy : PQHIEU(11/06/2021)
        T GetById(Guid entityId);

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="accountId">Tài khoản được thêm</param>
        /// <param name="entity">Bản ghi muốn thêm</param>
        /// <returns>Số lượng bản ghi được thêm thành công</returns>
        /// CreatedBy : PQHIEU(11/06/2021)
        int Insert(Guid accountId ,T entity);

        /// <summary>
        /// Cập nhật thông tin bản ghi
        /// </summary>
        /// <param name="accountId">Tài khoản được update</param>
        /// <param name="entityId">ID bản ghi muốn cập nhật</param>
        /// <param name="entity">Thông tin bản ghi mới</param>
        /// <returns>Số lượng bản ghi được cập nhật thành công</returns>
        /// CreatedBy : PQHIEU(11/06/2021)
        int Update(Guid accountId , Guid entityId, T entity);

        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="entityId">ID bản ghi muốn xóa</param>
        /// <returns>Số lượng bản ghi xóa thành công</returns>
        /// CreatedBy : PQHIEU(11/06/2021)
        int Delete(Guid entityId);

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi muốn thêm</param>
        /// <returns>Số lượng bản ghi được thêm thành công</returns>
        /// CreatedBy : PQHIEU(11/06/2021)
        int InsertWithoutAccount(T entity);

        /// <summary>
        /// Cập nhật một bản ghi
        /// </summary>
        /// <param name="entityId">ID bản ghi cần cập nhật</param>
        /// <param name="entity">Thông tin bản ghi</param>
        /// <returns></returns>
        int UpdateWithoutAccount(Guid entityId, T entity);


    }
}
