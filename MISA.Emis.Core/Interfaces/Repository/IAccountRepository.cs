using MISA.Emis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Interfaces.Repository
{
    public interface IAccountRepository:IBaseRepository<Account>
    {
        /// <summary>
        /// Lấy thông tin tài khoản theo tên đăng nhập
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <returns>Tài khoản có tên đăng nhập cần tìm</returns>
        /// CreatedBy : PQhieu(10/08/2021)
        Account GetAccountdByUserName(string userName);

        /// <summary>
        /// Lấy mật khẩu của tài khoản
        /// </summary>
        /// <param name="userName">Tên đăng nhập tài khoản</param>
        /// <returns>Mật khẩu của tài khoản cần lấy</returns>
        /// CreatedBy : PQhieu(10/08/2021)
        string GetPasswordByUserName(string userName);
    }
}
