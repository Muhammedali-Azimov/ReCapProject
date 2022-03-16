using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDAL
    {
        public void Add(Car car);
        public void Update(Car car);
        public void Delete(Car car);
        public List<Car> GetById(int Id);
        public List<Car> GetAll();

    }
}
