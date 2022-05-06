using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        public List<Car> GetAll();
        public Car Get();
        public void Add(Car car);
        public List<Car> GetByColorId(int id);
    }
}
