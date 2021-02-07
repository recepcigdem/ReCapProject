using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
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

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Add(Car car)
        {
            if (car.Description.Length<=2 || car.DailyPrice > 0)
            {
            _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Aracın açıklaması minimum 2 karakter olmalı, fiyatı 0 dan büyük olmalıdır.");
            }
        }

        public void Update(Car car)
        {
            if (car.Description.Length <= 2 || car.DailyPrice > 0)
            {
            _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("Aracın açıklaması minimum 2 karakter olmalı, fiyatı 0 dan büyük olmalıdır.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAllByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
