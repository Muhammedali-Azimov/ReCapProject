using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        readonly ICarDAL _carDAL;

        public CarManager(ICarDAL carDAL)
        {
            _carDAL = carDAL;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll());
        }


        public IResult Add(Car car)
        {
            if (car.Brand.Length >= 2 && car.DailyPrice > 0)
            {
                _carDAL.Add(car);
                return new SuccessResult();
            }
            else
            {
                if (car.Brand.Length < 2)
                {
                    return new ErrorResult("Car name must be a minimum of 2 characters");
                }
                else
                {
                    return new ErrorResult("The car daily price must be greater than 0");
                }

            }

        }


        public IDataResult<List<Car>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(p => p.ColorId == id));
        }

        public IResult Update(Car car)
        {
            _carDAL.Update(car);
            return new SuccessResult("Guncellendi");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetCarDetails());
        }
    }
}
