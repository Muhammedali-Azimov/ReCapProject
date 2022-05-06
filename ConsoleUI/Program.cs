using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());


            //Console.WriteLine(carManager.Get().Brand);
            Car car1 = new Car();
            car1.Id = 4;
            car1.Brand = "1";
            car1.ColorId = 3;
            car1.DailyPrice = 60;
            car1.Description = "TEst";
            car1.ModelYear = new DateTime(2015, 12, 25, 10, 30, 45);
            carManager.Add(car1);


            foreach (var item in carManager.GetByColorId(3))
            {
                Console.WriteLine(item.Brand);
            }
        }
    }
}
