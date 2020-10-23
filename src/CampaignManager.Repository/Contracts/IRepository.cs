using System;
using System.Linq;
using System.Linq.Expressions;

namespace CampaignManager.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> Find(Func<TEntity, bool> predicate);
        TEntity FirstOrDefault();
        TEntity FirstOrDefault(Func<TEntity, bool> predicate);
        void Add(TEntity entity);
        void Update(TEntity entity, Predicate<TEntity> predicate);
        void Delete(TEntity entity);
    }
}