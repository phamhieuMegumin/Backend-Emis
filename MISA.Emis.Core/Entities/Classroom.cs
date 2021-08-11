using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Entities
{
    /// <summary>
    /// Lớp học
    /// </summary>
    public class Classroom:BaseEntity
    {
        public Guid ClassroomId { get; set; }
        public Guid AccountId { get; set; }
        public string ClassroomName { get; set; }
        public string Category { get; set; }
    }
}
