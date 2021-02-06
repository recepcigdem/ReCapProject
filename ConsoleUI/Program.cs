using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //carManager.Add(new Car()
            //{
            //    BrandId = 3,
            //    ColorId = 2,
            //    DailyPrice = 340,
            //    ModelYear = 2017,
            //    Description = "Mercedes Lacivert 2017"
            //});

            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            //GetAll
            //foreach (Car car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}
        }


    }



}
