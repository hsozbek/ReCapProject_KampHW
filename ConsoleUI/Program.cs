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
        static ICarService _efCarService = new CarManager(new EfCarDal(), new CarValidator());


        static void Main(string[] args)
        {
            //GetCarsByColorId();
            //GetCarsByBrandId();
            //GetById();
            //GetAll();
            //Update();
            //Delete();
            //Add();
            //AddWithException();
        }

        private static void GetCarsByColorId()
        {
            foreach (Car car in _efCarService.GetCarsByColorId(1))
            {
                Console.WriteLine(car.Name);
            }
        }

        private static void GetCarsByBrandId()
        {
            foreach (Car car in _efCarService.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Name);
            }
        }

        private static void GetById()
        {
            Console.WriteLine(_efCarService.GetById(1).Name);
        }

        private static void GetAll()
        {
            foreach (Car car in _efCarService.GetAll())
            {
                Console.WriteLine(car.Name);
            }
        }

        private static void Update()
        {
            _efCarService.Update(new Car
            {
                Id = 3,
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 2500,
                Name = "Polo",
                ModelYear = 2019,
                Description = "Otomatik"
            });
        }

        private static void Delete()
        {
            _efCarService.Delete(new Car
            {
                Id = 3,
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 2500,
                Name = "Polo",
                ModelYear = 2019,
                Description = "Otomatik"
            });
        }

        private static void Add()
        {
            _efCarService.Add(new Car
            { BrandId = 1, ColorId = 1, DailyPrice = 2500, Name = "Polo", ModelYear = 2019, Description = "Otomatik" });
        }

        private static void AddWithException()
        {
            _efCarService.Add(new Car { Name = "a" });
        }
    }
}
