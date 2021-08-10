using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Entities
{
    /// <summary>
    /// Thông tin tài khoản khách hàng
    /// CreatedBy : PQHieu(10/08/2021)
    /// </summary>
    public class Account:BaseEntity
    {
        /// <summary>
        /// ID tài khoản
        /// CreatedBy : PQHieu(10/08/2021)
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Số điện thoại đăng ký tài khoản
        /// CreatedBy : PQHieu(10/08/2021)
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Mật khẩu tài khoản
        /// CreatedBy : PQHieu(10/08/2021)
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// CreatedBy : PQHieu(10/08/2021)
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email tạo tài khoản
        /// CreatedBy : PQHieu(10/08/2021)
        /// </summary>
        public string Email { get; set; }
    }
}
