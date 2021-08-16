using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Emis.Core.Entities;
using MISA.Emis.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MISA.Emis.Infracstructure.Repository
{
    public class ManageSubjectRepositoty : BaseRepository<ManageSubject>, IManageSubjectRepository
    {
        public ManageSubjectRepositoty(IConfiguration configuration):base(configuration)
        {

        }
        public IEnumerable<ManageSubject> GetManageSubjectById(Guid classId)
        {
            dynamicParameters.Add("@m_classroomId", classId);
            return _dbConnection.Query<ManageSubject>("Proc_GetManageSubjectByClassId", dynamicParameters, commandType: CommandType.StoredProcedure);
        }
    }
}
