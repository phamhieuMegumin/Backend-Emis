using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Entities
{
    public class FileUpload
    {
        /// <summary>
        /// File được truyền lên
        /// </summary>
        /// CreatedBy : PQHieu(22/08/2021)
        public IFormFile files { get; set; }
    }
}
