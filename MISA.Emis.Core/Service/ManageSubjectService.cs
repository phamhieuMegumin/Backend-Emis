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
    public class ManageSubjectService : BaseService<ManageSubject>, IManageSubjectService
    {
        IBaseRepository<ManageSubject> _baseRepository;
        IClassroomRepository _classroomRepository;
        public ManageSubjectService(IBaseRepository<ManageSubject> baseRepository, IClassroomRepository classroomRepository):base(baseRepository)
        {
            _baseRepository = baseRepository;
            _classroomRepository = classroomRepository;
        }
        public int InsertList(List<ManageSubject> listSubject)
        {
            var classId = _classroomRepository.GetNewestClassroomId();
            var rowEffects = 0;
            foreach (var subject in listSubject)
            {
                subject.ClassroomId = classId;
                var res = _baseRepository.InsertWithoutAccount(subject);
                if (res > 0)
                {
                    rowEffects++;
                }
            }
            return rowEffects;
        }
    }
}
