using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace DAO.Repository
{
    public class RepositoryBase : IRepository, IDisposable
    {
        protected ISession session = null;
        protected ITransaction transaction = null;

        public RepositoryBase()
        {
            session = Domain.NHConfiguration.NHibernateHelper.OpenSession();
        }

        public RepositoryBase(ISession session)
        {
            this.session = session;
        }

        //Transaction and Session management

        public void beginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void commitTransaction()
        {
            transaction.Commit();

            closeTransaction();
        }

        public void rollbackTransaction()
        {
            transaction.Dispose();

            closeTransaction();
            closeSession();
        }

        public void closeTransaction()
        {
            transaction.Dispose();
            transaction = null;
        }

        public void closeSession()
        {
            session.Close();
            session.Dispose();
            session = null;
        }

        //IRepository members

        public virtual void save(object obj)
        {
            session.SaveOrUpdate(obj);
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

        // IDispsable members

        public void Dispose()
        {
            if (transaction != null)
            {
                commitTransaction();
            }

            if (session != null)
            {
                session.Flush();
                closeSession();
            }
        }
    }
}
