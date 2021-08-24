using MISA.Emis.Core.Attributes;
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
        /// <summary>
        /// ID lớp học
        /// </summary>
        public Guid ClassroomId { get; set; }

        /// <summary>
        /// Mã lớp học
        /// </summary>
        public string ClassroomCode { get; set; }

        /// <summary>
        /// ID tài khoản thuộc lớp học
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Tên lớp học
        /// </summary>
        [Required("Không được để trống", "ClassroomName")]
        public string ClassroomName { get; set; }

        /// <summary>
        /// ID khối học
        /// </summary>
        [Required("Không được để trống", "GradeId")]
        public Guid GradeId { get; set; }

        /// <summary>
        /// Tên khối lớp
        /// </summary>
        public string GradeName { get; set; }

        /// <summary>
        /// Đường dẫn chứa ảnh lớp học
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Danh sách môn học của lớp
        /// </summary>
        public List<Guid> Subject { get; set; }

        /// <summary>
        /// Mô tả về lớp học 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Duyệt học sinh
        /// </summary>
        public int Approve { get; set; }
    }
}
