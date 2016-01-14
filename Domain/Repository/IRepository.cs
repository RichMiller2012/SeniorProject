using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepository
    {
        void save(object obj);
        void delete(object obj);
        object getById(Type objType, object objId);
        IQueryable<TEntity> toList<TEntity>();
    }
}
