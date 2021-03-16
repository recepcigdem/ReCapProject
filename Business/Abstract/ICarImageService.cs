using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();

        IDataResult<CarImage> Get(int id);

        IResult Add(CarImagesOperationDto carImagesOperationDto);

        IResult Update(CarImagesOperationDto carImagesOperationDto);

        IResult Delete(CarImage entity);

        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}
