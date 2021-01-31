using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal :ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1,BrandId = 1,ColorId = 1,DailyPrice = 300,Description = "2020 Renault Mavi",ModelYear = 2020},
                new Car{Id = 2,BrandId = 2,ColorId = 1,DailyPrice = 550,Description = "2019 Mercedes Mavi",ModelYear = 2019},
                new Car{Id = 3,BrandId = 2,ColorId = 2,DailyPrice = 500,Description = "2018 Mercedes Kırmızı",ModelYear = 2018},
                new Car{Id = 4,BrandId = 3,ColorId = 1,DailyPrice = 450,Description = "2020 BMW Mavi",ModelYear = 2020},
                new Car{Id = 5,BrandId = 3,ColorId = 2,DailyPrice = 400,Description = "2021 BMW Kırmızı",ModelYear = 2021},

            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            var carUpdated = _cars.SingleOrDefault(c => c.Id == car.Id);

            carUpdated.BrandId = car.BrandId;
            carUpdated.ColorId = car.ColorId;
            carUpdated.DailyPrice = car.DailyPrice;
            carUpdated.Description = car.Description;
            carUpdated.ModelYear = car.ModelYear;
        }

        public void Delete(Car car)
        {
            var carDeleted = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(carDeleted);
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByColorId(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }
    }
}
