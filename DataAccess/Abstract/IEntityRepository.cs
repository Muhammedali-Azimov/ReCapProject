﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        public List<T> GetAll(Expression<Func<T, bool>> filter = null); //error
        T Get(Expression<Func<T, bool>> filter = null);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);

    }
}