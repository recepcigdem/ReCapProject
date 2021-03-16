using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private ICarImageService _carImageService;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>( true, Messages.Get, _carDal.GetAll());
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Add);

        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        { 
                _carDal.Update(car);
                return new SuccessResult(Messages.Update);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Delete);
        }

        public IDataResult<List<CarDetailDto>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>( true, Messages.Get, _carDal.GetCarDetails(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>( true, Messages.Get, _carDal.GetCarDetails(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(true, Messages.Get, _carDal.GetCarDetails(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( true, Messages.Get,_carDal.GetCarDetails());
        }

        public IDataResult<CarDetailAndImagesDto> GetCarDetailAndImagesDto(int carId)
        {
            var result = _carDal.GetCarDetail(carId);
            var imageResult = _carImageService.GetAllByCarId(carId);
            if (result == null || imageResult.Success == false)
            {
                return new ErrorDataResult<CarDetailAndImagesDto>(Messages.Get);
            }

            var carDetailAndImagesDto = new CarDetailAndImagesDto
            {
                Car = result,
                CarImages = imageResult.Data
            };

            return new SuccessDataResult<CarDetailAndImagesDto>(carDetailAndImagesDto, Messages.Get);
        }
    }
}
