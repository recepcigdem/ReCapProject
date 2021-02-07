﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAllByColorId(int ColorId);
        List<Car> GetAllByBrandId(int BrandId);
        List<CarDetailDto> GetCarDetails();
    }
}
