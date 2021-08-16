using MISA.Emis.Core.Entities;
using MISA.Emis.Core.Interfaces.Repository;
using MISA.Emis.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Service
{
    public class ClassroomService:BaseService<Classroom>, IClassroomService
    {
        IBaseRepository<Classroom> _baseRepository;
        IManageSubjectRepository _manageSubjectRepository;
        public ClassroomService(IBaseRepository<Classroom> baseRepository, IManageSubjectRepository manageSubjectRepository) :base(baseRepository)
        {
            _baseRepository = baseRepository;
            _manageSubjectRepository = manageSubjectRepository;
        }

        public Classroom GetClassroomById(Guid classroomId)
        {
            var classroom = _baseRepository.GetById(classroomId);
            var listManageSubject = _manageSubjectRepository.GetManageSubjectById(classroomId);
            List<Guid> listSubject = new List<Guid>();
            foreach (var manageSubject in listManageSubject)
            {
                listSubject.Add(manageSubject.SubjectId);
            }
            classroom.Subject = listSubject;
            return classroom;
        }

    }
}
