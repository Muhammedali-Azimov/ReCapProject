using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDAL _carDAL;

        public CarManager(ICarDAL carDAL)
        {
            _carDAL = carDAL;
        }

        public List<Car> GetAll()
        {
            return _carDAL.GetAll();
        }


        public void Add(Car car)
        {
            if (car.Brand.Length >= 2 && car.DailyPrice > 0)
            {
                _carDAL.Add(car);
            }
            else
            {
                if (car.Brand.Length < 2)
                {
                    Console.WriteLine("Car name must be a minimum of 2 characters");
                }
                else
                {
                    Console.WriteLine("The car daily price must be greater than 0");
                }

            }

        }

        public Car Get()
        {
            return _carDAL.Get();
        }


        public List<Car> GetByColorId(int id)
        {
            return _carDAL.GetAll(p => p.ColorId == id);
        }
    }
}
