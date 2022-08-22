using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Helpers.Filehelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    internal class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelper.Upload(file, "wwwroot\\Upload\\");
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Resim Başarıyla Yüklendii");
        }


        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(carImage.ImagePath);
            return new SuccessResult("Sekil Silindi");
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, "wwwroot\\Upload\\", carImage.ImagePath);
            carImage.Date = DateTime.Now; ;
            _carImageDal.Update(carImage);
            return new SuccessResult("Sekil Yenilendi");
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result>5)
            {
                return new ErrorResult("Sekil Limiti Asildi");
            }
            return new SuccessResult();
        }
    }
}
