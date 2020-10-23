using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CampaignManager.Data;

namespace CampaignManager.Repository
{
    public class MemoryRepository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _set;

        public MemoryRepository()
        {
            var context = new MemoryContext();
            _set = context.Set<T>();
        }
        
        public IQueryable<T> FindAll()
        {
            return _set.AsQueryable();
        }

        public IQueryable<T> Find(Func<T, bool> predicate)
        {
            return _set.Where(predicate).AsQueryable();
        }
        
        public T FirstOrDefault()
        {
            return _set.FirstOrDefault();
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return _set.FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
            _set.Add(entity);
        }

        public void Update(T entity, Predicate<T> predicate)
        {
            var index = _set.FindIndex(predicate);

            if (index != -1) _set[index] = entity;
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }
    }
}