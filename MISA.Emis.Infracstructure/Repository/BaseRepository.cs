using MISA.Emis.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace MISA.Emis.Infracstructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        #region Field
        protected IDbConnection _dbConnection;
        IConfiguration _configuration;
        protected DynamicParameters dynamicParameters;
        string _connectString;
        string _className;
        #endregion

        #region Construtor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DefaultConnection");
            _dbConnection = new MySqlConnection(_connectString);
            dynamicParameters = new DynamicParameters();
            _className = typeof(T).Name;
        }
        #endregion

        #region Methods
        public IEnumerable<T> GetAll()
        {
            return _dbConnection.Query<T>($"Proc_Get{_className}s", commandType: CommandType.StoredProcedure);
        }

        public T GetById(Guid entityId)
        {
            dynamicParameters.Add($"@m_{_className}Id", entityId);
            return _dbConnection.QueryFirstOrDefault<T>($"Proc_Get{_className}ById", dynamicParameters ,commandType: CommandType.StoredProcedure);
        }

        public int Insert(T entity)
        {
            MappingParameterValue(entity);
            return _dbConnection.Execute($"Proc_Insert{_className}", dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public int Update(Guid entityId, T entity)
        {
            dynamicParameters.Add($"@m_{_className}Id", entityId);
            MappingParameterValue(entity);
            return _dbConnection.Execute($"Proc_Update{_className}", dynamicParameters, commandType: CommandType.StoredProcedure);
        }
        public int Delete(Guid entityId)
        {
            dynamicParameters.Add($"@m_{_className}Id", entityId);
            return _dbConnection.Execute($"Proc_Delete{_className}", dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Thực hiện gán giá trị cho các tham số đầu vào của store với các property
        /// </summary>
        /// <param name="entity">Đối tượng cần mapping</param>
        /// CreatedBy : PQHieu 11/06/2021
        void MappingParameterValue(T entity)
        {
            // lấy tất cả thuộc tính của đối tượng
            var properties = typeof(T).GetProperties();
            // Thực hiện lặp lần lượt cac thuộc tính
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                dynamicParameters.Add($"m_{propertyName}", propertyValue);
            }
        } 
        #endregion

    }
}
