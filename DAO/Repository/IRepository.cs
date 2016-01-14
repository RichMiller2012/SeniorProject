using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repository
{
    public interface IRepository
    {
        void save(object obj);
        void delete(object obj);
        object getById(Type objType, object objId);
        IQueryable<TEntity> toList<TEntity>();
    }
}
