using MISA.Emis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Interfaces.Service
{
    public interface IAccountService:IBaseService<Account>
    {
        /// <summary>
        /// Đăng nhập vào hệ thống
        /// </summary>
        /// <param name="userName">Tên dăng nhập</param>
        /// <param name="password">Mật khẩu đăng nhập</param>
        /// <returns>
        /// Token - Token trả về cho người dùng
        /// AccountInfo - Thông tin tài khoản người dùng
        /// </returns>
        /// CreatedBy : PQHieu(10/08/2021)
        ResponseLogin Login(string userName, string password);
    }
}
