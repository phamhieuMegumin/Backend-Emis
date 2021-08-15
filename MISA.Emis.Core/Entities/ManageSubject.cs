using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Entities
{
    /// <summary>
    /// Quản lý lớp học và môn học
    /// </summary>
    public class ManageSubject
    {
        /// <summary>
        /// ID lớp học
        /// </summary>
        public Guid ClassroomId { get; set; }

        /// <summary>
        /// ID môn học 
        /// </summary>
        public Guid SubjectId { get; set; }
    }
}
