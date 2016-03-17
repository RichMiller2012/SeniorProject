using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAO.Data
{
    public abstract class AbstractBaseDAO
    {
        protected ISession session = Domain.NHConfiguration.NHibernateHelper.OpenSession();

        public virtual void save(object obj)
        {
            session.SaveOrUpdate(obj);
            session.Flush();
        }

        public virtual void delete(object obj)
        {
            session.Delete(obj);
        }

        public virtual object getById(Type objType, object objId)
        {
            return session.Load(objType, objId);
        }

        public virtual IQueryable<TEntity> toList<TEntity>()
        {
            return (from entity in session.Query<TEntity>() select entity);
        }
    }
}
