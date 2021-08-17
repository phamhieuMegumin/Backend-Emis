using MISA.Emis.Core.Attributes;
using MISA.Emis.Core.Interfaces.Repository;
using MISA.Emis.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Emis.Core.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual int Insert(Guid accountId, T entity)
        {
            return _baseRepository.Insert(accountId, entity);
        }

       

        public virtual int InsertWithoutAccount(T entity)
        {

            return _baseRepository.InsertWithoutAccount(entity);
        }

        public int Update(Guid accountId, Guid entityId, T entity)
        {
            return _baseRepository.Update(accountId, entityId, entity);
        }

        public int UpdateWithoutAccount(Guid entityId, T entity)
        {
            return _baseRepository.UpdateWithoutAccount(entityId, entity);
        }

        //protected virtual void Validate(T entity)
        //{
        //    var properties = typeof(T).GetProperties();
        //    foreach (var property in properties)
        //    {
        //        var attributesRequired = property.GetCustomAttributes(typeof(Required), true);

        //    }
        //}
    }
}
