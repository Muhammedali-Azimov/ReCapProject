using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfRepositoryBase<Car, TestCarDbContext>, ICarDAL
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using TestCarDbContext context = new TestCarDbContext();
            
                var result = from c in context.Cars
                             join k in context.Colors
                             on c.ColorId equals k.Id
                             select new CarDetailDto
                             {
                                 CarName = c.Brand,
                                 ColorName = k.Name
                             };
                return result.ToList();

            
        }
    }
}
