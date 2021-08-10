using Microsoft.Extensions.Configuration;
using MISA.Emis.Core.Entities;
using MISA.Emis.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using System.Data;

namespace MISA.Emis.Infracstructure.Repository
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        
        public AccountRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public Account GetAccountdByUserName(string userName)
        {
            var sqlCommand = "Proc_GetAccountByUserName";
            dynamicParameters.Add(@"m_userName", userName);
            return _dbConnection.QueryFirstOrDefault<Account>(sqlCommand, dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public string GetPasswordByUserName(string userName)
        {
            var sqlCommand = "Proc_GetPasswordByUserName";
            dynamicParameters.Add(@"m_userName", userName);
            return _dbConnection.QueryFirstOrDefault<string>(sqlCommand, dynamicParameters, commandType: CommandType.StoredProcedure);
        }
    }
}
