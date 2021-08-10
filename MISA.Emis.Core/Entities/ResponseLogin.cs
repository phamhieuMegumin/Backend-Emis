using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Entities
{
    public class ResponseLogin
    {
        /// <summary>
        /// Token trả về khi đăng nhập thành công
        /// </summary>
        /// CreatedBy : PQHieu(10/08/2021)
        public string Token { get; set; }

        /// <summary>
        /// Thông tin tài khoản đăng nhập
        /// </summary>
        /// CreatedBy : PQHieu(10/08/2021)
        public Account AccountInfo { get; set; }
    }
}
