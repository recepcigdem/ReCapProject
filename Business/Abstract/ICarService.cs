using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>> GetAllByColorId(int ColorId);
        IDataResult<List<CarDetailDto>> GetAllByBrandId(int BrandId);
        IDataResult<List<CarDetailDto>> GetAllByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<CarDetailAndImagesDto> GetCarDetailAndImagesDto(int carId);
    }
}
