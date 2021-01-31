using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static ICarService _carService = new CarManager(new InMemoryCarDal());
        static void Main(string[] args)
        {
            //Update();
            //GetById();
            //Delete();
            //Add();
            //GetAll();
        }

        private static void Update()
        {
            _carService.Update(new Car()
            {
                Id = 2, BrandId = 3, ModelYear = 2018, ColorId = 3, DailyPrice = 3500, Description = "Manual şanzıman 7 ileri"
            });
        }

        private static void GetById()
        {
            Console.WriteLine("Id: " + _carService.GetById(2).Id + " olan araba getirildi");
        }

        private static void Delete()
        {
            _carService.Delete(new Car()
            {
                Id = 2, BrandId = 3, ModelYear = 2018, ColorId = 3, DailyPrice = 3500, Description = "Otomatik şanzıman 7 ileri"
            });
        }

        private static void Add()
        {
            _carService.Add(new Car()
                {Id = 6, BrandId = 2, ColorId = 2, DailyPrice = 2500, ModelYear = 2010, Description = "Manual vites 6 ileri"});
        }

        private static void GetAll()
        {
            
            foreach (Car car in _carService.GetAll())
            {
                Console.WriteLine(car.BrandId);
            }
        }
    }
}
