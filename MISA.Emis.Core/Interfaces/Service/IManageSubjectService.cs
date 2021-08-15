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
    }
}
