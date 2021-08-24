using Microsoft.Extensions.Configuration;
using MISA.Emis.Core.Entities;
using MISA.Emis.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace MISA.Emis.Infracstructure.Repository
{
    public class ClassroomImageRepository : BaseRepository<ClassroomImage>, IClassroomImageRepository
    {
        public ClassroomImageRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public ClassroomImage GetImageUrl(Guid classId)
        {
            dynamicParameters.Add("@m_classroomId", classId);
            return _dbConnection.QueryFirstOrDefault<ClassroomImage>("Proc_getClassroomImageById", dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public int Update(ClassroomImage classroomImage)
        {
            base.MappingParameterValue(classroomImage);
            return _dbConnection.Execute("Proc_UpdateClassroomImage", dynamicParameters, commandType: CommandType.StoredProcedure);
        }
    }
}
