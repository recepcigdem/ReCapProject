﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    {
        
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAllByBrandId(int brandId);
        List<Car> GetAllByColorId(int colorId);
    }
}
