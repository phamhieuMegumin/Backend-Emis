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
    public class ClassroomRepository : BaseRepository<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(IConfiguration configuration):base(configuration)
        {

        }
        public Guid GetNewestClassroomId()
        {
            return _dbConnection.ExecuteScalar<Guid>("Proc_GetNewestClass", commandType: CommandType.StoredProcedure);
        }
    }
}
