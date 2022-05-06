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
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //Color color1 = new Color();
            //color1.Id = 1;
            //color1.Name = "Sari";
            //colorManager.Add(color1);
            //Color color2 = new Color();
            //color2.Id = 2;
            //color2.Name = "Qirmizi";
            //colorManager.Add(color2);

            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.CarName + "///" + item.ColorName);
            }


        }

        private static void ElaveEt(CarManager carManager)
        {
            Car car1 = new Car();
            car1.Brand = "Masin";
            car1.ColorId = 3;
            car1.DailyPrice = 60;
            car1.Description = "TEst";
            car1.ModelYear = new DateTime(2015, 12, 25, 10, 30, 45);
            carManager.Add(car1);
        }

        
    }
}
