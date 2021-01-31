using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            //Ekleme
            //carManager.Add(new Car
            //{
            //    Id = 6,
            //    BrandId = 3,
            //    ColorId = 2,
            //    DailyPrice = 1000,
            //    Description = "Deneme",
            //    ModelYear = 2015
            //});


            //Güncelleme
            //carManager.Update(new Car
            //{
            //    Id = 5,
            //    BrandId = 3,
            //    ColorId = 2,
            //    DailyPrice = 1000,
            //    Description = "deneme",
            //    ModelYear = 2015
            //});
            
            //Silme
            //carManager.Delete(new Car
            //{
            //    Id = 5,
            //});


            //GetAllByBrandId
            //foreach (Car car in carManager.GetAllByBrandId(2))
            //{
            //    Console.WriteLine(car.Description);
            //}


            //GetAllByColorId
            foreach (Car car in carManager.GetAllByColorId(2))
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
