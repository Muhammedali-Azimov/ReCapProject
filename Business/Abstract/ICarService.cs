using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        public List<Car> GetAll();
        public void Add(Car car);
        public List<Car> GetByColorId(int id);
        public void Update(Car car);
        public List<CarDetailDto> GetCarDetails();
    }
}
