using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDAL
    {
        public void Add(Car entity)
        {
            using (TestCarDbContext testCarDbContext = new TestCarDbContext())
            {
                var addedEntity = testCarDbContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                testCarDbContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (TestCarDbContext testCarDbContext = new TestCarDbContext())
            {
                var deletedEntity = testCarDbContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                testCarDbContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            using (TestCarDbContext testCarDbContext = new TestCarDbContext())
            {
                return testCarDbContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (TestCarDbContext testCarDbContext = new TestCarDbContext())
            {
                return filter == null 
                    ? testCarDbContext.Set<Car>().ToList() 
                    : testCarDbContext.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (TestCarDbContext testCarDbContext = new TestCarDbContext())
            {
                var updatedEntity = testCarDbContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                testCarDbContext.SaveChanges();
            }
        }
    }
}
