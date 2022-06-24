using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental  rental)
        {
            if (CheckReturnStatus(rental.CarId))
            {
                _rentalDal.Add(rental);
                return new SuccessResult("Rental Əlavə Edildi");
            }

            return new ErrorResult("Masin Movcud Deyil");

        }


        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }
        private bool CheckReturnStatus(int carId)
        {
            var rental =_rentalDal.Get(c => c.CarId == carId);
            if (rental.ReturnDate == null)
            {
                return false;
            }
            return true;
        }
    }
}
