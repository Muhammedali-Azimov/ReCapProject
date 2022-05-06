using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    
    public class InMemoryDAL:ICarDAL
    {
    List<Car> _cars;    
        public InMemoryDAL()
        {
            _cars = new List<Car> {
                new Car {Id = 1, Brand = "Lexus", ColorId = 2, DailyPrice = 4241, Description= "YTest Car" },
                new Car {Id = 2, Brand = "Kia", ColorId = 1, DailyPrice = 45252, Description= "YTest Car" },
                new Car {Id = 3, Brand = "Mercedes", ColorId = 1, DailyPrice = 52542, Description= "YTest Car" },
                new Car {Id = 4, Brand = "Porche", ColorId = 2, DailyPrice = 877542, Description= "YTest Car" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }


        public void Delete(Car car)
        {
            Car CarToDelete = null;
            CarToDelete = (Car)_cars.Where(c=>c.Id == car.Id);
            _cars.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return filter == null
                ? _cars
                : _cars;
        }

        public List<Car> GetById(int Id)
        {
            return (List<Car>)_cars.Where(c => c.ColorId == Id);
        }


        public void Update(Car car)
        {
            Car CarToUpdate = null;
            CarToUpdate = (Car)_cars.Where(c => c.Id == car.Id);
            CarToUpdate.Brand = car.Brand;
            CarToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
