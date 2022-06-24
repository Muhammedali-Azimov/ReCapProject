using Core.Utilities.Results;
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
        public IDataResult<List<Car>> GetAll();
        public IResult Add(Car car);
        public IDataResult<List<Car>> GetByColorId(int id);
        public IResult Update(Car car);
        public IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
