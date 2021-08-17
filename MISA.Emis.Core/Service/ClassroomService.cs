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
        IClassroomRepository _classroomRepository;
        IManageSubjectRepository _manageSubjectRepository;
        public ClassroomService(IClassroomRepository classroomRepository, IManageSubjectRepository manageSubjectRepository) :base(classroomRepository)
        {
            _classroomRepository = classroomRepository;
            _manageSubjectRepository = manageSubjectRepository;
        }

        public Classroom GetClassroomById(Guid classroomId)
        {
            var classroom = _classroomRepository.GetById(classroomId);
            var listManageSubject = _manageSubjectRepository.GetManageSubjectById(classroomId);
            List<Guid> listSubject = new List<Guid>();
            foreach (var manageSubject in listManageSubject)
            {
                listSubject.Add(manageSubject.SubjectId);
            }
            classroom.Subject = listSubject;
            return classroom;
        }
        public override int Insert(Guid accountId, Classroom entity)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var newCode = new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            while (_classroomRepository.CheckClassroomCodeExist(newCode))
            {
                newCode = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            entity.ClassroomCode = newCode;
            return base.Insert(accountId, entity);
        }

    }
}
