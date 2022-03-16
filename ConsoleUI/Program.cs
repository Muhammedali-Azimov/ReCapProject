using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryDAL());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Brand);
            }
        }
    }
}
