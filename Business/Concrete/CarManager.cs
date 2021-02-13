using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), true, Messages.Get);
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length<=2 || car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.Add);
            }
            else
            {
                return new ErrorResult(Messages.MinCharacter +" "+ Messages.MinPrice);
                
            }
        }

        public IResult Update(Car car)
        {
            if (car.Description.Length <= 2 || car.DailyPrice > 0)
            {
            _carDal.Update(car);
            return new SuccessResult(Messages.Update);
            }
            else
            {
                return new ErrorResult(Messages.MinCharacter + " " + Messages.MinPrice);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Delete);
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), true, Messages.Get);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), true, Messages.Get);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), true, Messages.Get);
        }
    }
}
