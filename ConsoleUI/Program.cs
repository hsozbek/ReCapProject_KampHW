using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static ICarService _efCarService = new CarManager(new EfCarDal());
        static ICustomerService _customerService = new CustomerManager(new EfCustomerDal());

        static void Main(string[] args)
        {
            AddRentalTest();

            //GetCarDetails();
            //GetCarsByColorId();
            //GetCarsByBrandId();
            //GetById();
            //GetAll();
            //Update();
            //Delete();
            //Add();
            //AddWithException();
        }

        private static void AddRentalTest()
        {
            IRentalService _rentalService = new RentalManager(new EfRentalDal());

            var result = _rentalService.Add(new Rental {CarId = 5, CustomerId = 1, RentDate = new DateTime(2021, 02, 13)});
            Console.WriteLine(result.Message);
        }

        private static void GetCarDetails()
        {
            foreach (var carDetailDto in _efCarService.GetCarDetails().Data)
            {
                Console.WriteLine("******ARAÇ DETAY******");
                Console.WriteLine("Car Id : {0}\nCar Name : {1}\nCar Brand : {2}\nCar Color : {3}", carDetailDto.Id,
                    carDetailDto.Name, carDetailDto.BrandName, carDetailDto.ColorName);
            }
        }

        private static void GetCarsByColorId()
        {
            foreach (Car car in _efCarService.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(car.Name);
            }
        }

        private static void GetCarsByBrandId()
        {
            foreach (Car car in _efCarService.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.Name);
            }
        }

        private static void GetById()
        {
            Console.WriteLine(_efCarService.GetById(1).Data.Name);
        }

        private static void GetAll()
        {
            foreach (Car car in _efCarService.GetAll().Data)
            {
                Console.WriteLine(car.Name);
            }
        }

        private static void Update()
        {
            _efCarService.Update(new Car
            {
                Id = 2002,
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 2500,
                Name = "Polo",
                ModelYear = 2019,
                Description = "Manual"
            });
        }

        private static void Delete()
        {
            _efCarService.Delete(new Car
            {
                Id = 2002,
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 2500,
                Name = "Polo",
                ModelYear = 2019,
                Description = "Manual"
            });
        }

        private static void Add()
        {
            _efCarService.Add(new Car
            {
                BrandId = 1,
                ColorId = 1, 
                DailyPrice = 2500,
                Name = "Polo",
                ModelYear = 2019,
                Description = "Otomatik"
            });
        }

        private static void AddWithException()
        {
           var result=_efCarService.Add(new Car { Name = "d" });
           Console.WriteLine(result.Message);
        }
    }
}
