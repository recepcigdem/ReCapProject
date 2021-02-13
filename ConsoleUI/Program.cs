using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.Dtos;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {
            //AddCar();

            //GetAllCar();

            //GetAllByColorId(2);

            //GetAllByBrandId(1);

            //UpdateCar();

            //DeleteCar();

            //CarDetailDto();

            //AddUser();
            
            //AddCustomer();

            AddRental();
        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental() {CarId = 1, CustomerId = 1, ReturnDate = DateTime.Now});
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User() {FirstName = "Recep", LastName = "Çiğdem", Email = "aa@hotmail.com", Password = "1234"});
            userManager.Add(new User() {FirstName = "Yavuz", LastName = "Çiğdem", Email = "ba@hotmail.com", Password = "1234"});
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer() {UserId = 1, CompanyName = "Kayra Holding"});
            customerManager.Add(new Customer() {UserId = 2, CompanyName = "Torku Holding"});
        }

        private static void CarDetailDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (CarDetailDto car in result.Data)
                {
                    Console.WriteLine("Model: " + car.ModelYear + " Marka: " + car.BrandName + " Renk: " + car.ColorName +
                                      " Günlük Fiyat: " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void DeleteCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car
            { Id = 1 });
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (CarDetailDto car in result.Data)
                {
                    Console.WriteLine("Model: " + car.ModelYear + " Marka: " + car.BrandName + " Renk: " + car.ColorName +
                                      " Günlük Fiyat: " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void UpdateCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car
            { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 300, Description = "Renault Mavi 2014", ModelYear = 2014 });
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (CarDetailDto car in result.Data)
                {
                    Console.WriteLine("Model: " + car.ModelYear + " Marka: " + car.BrandName + " Renk: " + car.ColorName +
                                      " Günlük Fiyat: " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void GetAllByBrandId(int brandId)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (CarDetailDto car in result.Data)
                {
                    Console.WriteLine("Model: " + car.ModelYear + " Marka: " + car.BrandName + " Renk: " + car.ColorName +
                                      " Günlük Fiyat: " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void GetAllByColorId(int colorId)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (CarDetailDto car in result.Data)
                {
                    Console.WriteLine("Model: " + car.ModelYear + " Marka: " + car.BrandName + " Renk: " + car.ColorName +
                                      " Günlük Fiyat: " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void GetAllCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (CarDetailDto car in result.Data)
                {
                    Console.WriteLine("Model: " + car.ModelYear + " Marka: " + car.BrandName + " Renk: " + car.ColorName +
                                      " Günlük Fiyat: " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car()
            {
                BrandId = 3,
                ColorId = 2,
                DailyPrice = 340,
                ModelYear = 2017,
                Description = "Mercedes Lacivert 2017"
            });
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (CarDetailDto car in result.Data)
                {
                    Console.WriteLine("Model: " + car.ModelYear + " Marka: " + car.BrandName + " Renk: " + car.ColorName +
                                      " Günlük Fiyat: " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }



}
