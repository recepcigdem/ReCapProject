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

            carManager.Add(new Car {BrandId = 3, ColorId = 4, ModelYear = 2019, DailyPrice = 450, Description = "Deneme"});

            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
                
            }
        }
    }
}
