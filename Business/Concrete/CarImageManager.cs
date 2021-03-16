using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImagesOperationDto carImagesOperationDto)
        {
            var result = BusinessRules.Run(
                CheckCarImageCount(carImagesOperationDto.CarId));
            if (result != null)
            {
                return result;
            }

            foreach (var file in carImagesOperationDto.Images)
            {
                _carImageDal.Add(new CarImage
                {
                    CarId = carImagesOperationDto.CarId,
                    ImagePath = FileProcessHelper.Upload(DefaultNameOrPath.ImageDirectory, file).Data
                });
            }

            return new SuccessResult(Messages.AddCarImageMessage);
        }

        public IResult Delete(CarImage entity)
        {
            var imageData = _carImageDal.Get(p => p.CarImageId == entity.CarImageId);
            FileProcessHelper.Delete(imageData.ImagePath);
            _carImageDal.Delete(imageData);
            return new SuccessResult(Messages.DeleteCarImageMessage);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarImageId == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImagesOperationDto carImagesOperationDto)
        {
            foreach (var file in carImagesOperationDto.Images)
            {
                var result = BusinessRules.Run(
                    CheckIfCarImagesId(carImagesOperationDto.CarImageId),
                    CheckCarImageCount(carImagesOperationDto.CarId)
                );
                if (result != null)
                {
                    return result;
                }

                FileProcessHelper.Delete(_carImageDal.Get(p => p.CarImageId == carImagesOperationDto.CarImageId).ImagePath);
                _carImageDal.Update(new CarImage
                {
                    CarImageId = carImagesOperationDto.CarImageId,
                    CarId = carImagesOperationDto.CarId,
                    ImagePath = FileProcessHelper.Upload(DefaultNameOrPath.ImageDirectory, file).Data
                });
            }

            return new SuccessResult(Messages.EditCarImageMessage);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {


            var getAllbyCarIdResult = _carImageDal.GetAll(p => p.CarId == carId);
            if (getAllbyCarIdResult.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>
                {
                    new CarImage
                    {
                        CarImageId = -1,
                        CarId = carId,
                        Date = DateTime.MinValue,
                        ImagePath = DefaultNameOrPath.NoImagePath
                    }
                });
            }

            return new SuccessDataResult<List<CarImage>>(getAllbyCarIdResult);
        }

        #region Car Image Business Rules

        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(p => p.CarId == carId).Count > 4)
            {
                return new ErrorResult(Messages.AboveImageAddingLimit);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarImagesId(int Id)
        {
            if (_carImageDal.Get(p => p.CarImageId == Id) == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            return new SuccessResult();
        }

        #endregion Car Image Business Rules
    

}
}
