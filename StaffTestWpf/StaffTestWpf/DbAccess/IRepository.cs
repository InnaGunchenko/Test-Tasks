using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StaffTestWpf.DbAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void SaveOrUpdate(TEntity entity);
        void Save(TEntity entity);
       // void Update(TEntity entity);
        void Delete(TEntity entity);
     //   void Reset();
        //IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        //TEntity GetEntity(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll();
    }
}