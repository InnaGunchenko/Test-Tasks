using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StaffTestWpf.DbAccess
{
    public abstract class DbRepository<TEntity> where TEntity : class, new()
    {
        private readonly IDbFactory dbFactory;
        protected DbRepository(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public virtual void SaveOrUpdate(TEntity entity)
        {
            using (ISession session = dbFactory.Open())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    CommitChanges(session, transaction);
                }
            }
        }
        
        public virtual void Save(TEntity entity)
        {
            using (ISession session = dbFactory.Open())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    CommitChanges(session, transaction);
                }
            }
        }
        
        public virtual void Delete(TEntity entity)
        {
            using (ISession session = dbFactory.Open())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    CommitChanges(session, transaction);
                }
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (ISession session = dbFactory.Open())
            {
                return session.QueryOver<TEntity>().List();
            }
        }

        private void CommitChanges(ISession session, ITransaction transaction)
        {
            transaction.Commit();
            session.Flush();
            if (session != null)
            {
                session.Close();
            }
        }
    }
}