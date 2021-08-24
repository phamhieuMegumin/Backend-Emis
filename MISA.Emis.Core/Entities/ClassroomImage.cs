using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Entities
{
    /// <summary>
    /// Hình ảnh lớp học
    /// </summary>
    /// CreatedBy : PQHieu(23/08/2021)
    public class ClassroomImage:BaseEntity
    {
        public ClassroomImage(Guid ClassroomId, string ImageName, string ImageUrl)
        {
            this.ClassroomId = ClassroomId;
            this.ImageName = ImageName;
            this.ImageUrl = ImageUrl;
        }
        public ClassroomImage()
        {

        }
        /// <summary>
        /// ID hình ảnh
        /// </summary>
        public Guid ImageId { get; set; }
        /// <summary>
        /// ID lớp học
        /// </summary>
        public Guid ClassroomId { get; set; }
        /// <summary>
        /// Tên hình ảnh
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// Đường dẫn hình ảnh
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
