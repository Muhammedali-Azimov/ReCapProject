using Core.Entities;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext testCarDbContext = new TContext())
            {
                var addedEntity = testCarDbContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                testCarDbContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext testCarDbContext = new TContext())
            {
                var deletedEntity = testCarDbContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                testCarDbContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext testCarDbContext = new TContext())
            {
                return testCarDbContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext testCarDbContext = new TContext())
            {
                return filter == null
                    ? testCarDbContext.Set<TEntity>().ToList()
                    : testCarDbContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext testCarDbContext = new TContext())
            {
                var updatedEntity = testCarDbContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                testCarDbContext.SaveChanges();
            }
        }
    }
}
