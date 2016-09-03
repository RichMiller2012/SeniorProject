using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Domain.NHConfiguration;

namespace DAO.Data
{
    public abstract class AbstractBaseDAO
    {
        protected ISession session = Domain.NHConfiguration.NHibernateHelper.OpenSession();

        public virtual int save(object obj)
        {
            obj = session.Merge(obj);
            int id = (int)session.GetIdentifier(obj);
            session.Flush();
            return id;
        }

        public virtual int update(object obj)
        {
            obj = session.Merge(obj);
            int id = (int)session.GetIdentifier(obj);
            session.Flush();

            return id;
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
