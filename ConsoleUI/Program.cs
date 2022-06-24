using Business.Abstract;
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

            IColorService colorService = new ColorManager(new EfColorDal());
            colorService.Add(new Color { Name = "Sari" });
            foreach (var d in colorService.GetAll().Data)
            {
                Console.WriteLine(d.Name);          
            } 

        }

        public static void ElaveEt(CarManager carManager)
        {
            Car car1 = new Car
            {
                Brand = "Masin",
                ColorId = 3,
                DailyPrice = 60,
                Description = "TEst",
                ModelYear = new DateTime(2015, 12, 25, 10, 30, 45)
            };
            carManager.Add(car1);
        }

        
    }
}
