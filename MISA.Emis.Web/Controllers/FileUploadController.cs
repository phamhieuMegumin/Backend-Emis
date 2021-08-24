using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Emis.Core.Entities;
using MISA.Emis.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Emis.Web.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        IClassroomRepository _classroomRepository;
        IClassroomImageRepository _classroomImageRepository;
        public static IWebHostEnvironment _webHostEnvironment;
        public FileUploadController(IWebHostEnvironment webHostEnvironment, IClassroomRepository classroomRepository, IClassroomImageRepository classroomImageRepository)
        {
            _classroomImageRepository = classroomImageRepository;
            _classroomRepository = classroomRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile fileUpload)
        {
            try
            {
                if (fileUpload.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\upload\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var classId = _classroomRepository.GetNewestClassroomId();
                    var newImage = new ClassroomImage(classId, fileUpload.FileName, path + fileUpload.FileName);
                    _classroomImageRepository.InsertWithoutAccount(newImage);
                    using (FileStream fileStream = System.IO.File.Create(path + fileUpload.FileName))
                    {
                        fileUpload.CopyTo(fileStream);
                        fileStream.Flush();
                        return Ok();
                    }
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }
        [HttpGet("{classroomId}")]
        public async Task<IActionResult> Get(Guid classroomId)
        {
            //string path = _webHostEnvironment.WebRootPath + "\\upload\\";
            //string filePath = path + fileName + ".png";
            var image = _classroomImageRepository.GetImageUrl(classroomId);
            if (System.IO.File.Exists(image.ImageUrl))
            {
                byte[] b = System.IO.File.ReadAllBytes(image.ImageUrl);
                return File(b, "image/png");
            }
            return null;
        }
        [HttpPut("{classroomId}")]
        public IActionResult Update(Guid classroomId, IFormFile fileUpload)
        {
            if (fileUpload.Length > 0)
            {
                string path = _webHostEnvironment.WebRootPath + "\\upload\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var newImage = new ClassroomImage(classroomId, fileUpload.FileName, path + fileUpload.FileName);
                _classroomImageRepository.Update(newImage);
                using (FileStream fileStream = System.IO.File.Create(path + fileUpload.FileName))
                {
                    fileUpload.CopyTo(fileStream);
                    fileStream.Flush();
                    return Ok();
                }
            }
            else
            {
                return NoContent();
            }
        }
       
    }
}
