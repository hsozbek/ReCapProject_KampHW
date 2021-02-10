using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car(){Id = 1,BrandId = 1,ModelYear = 2015,ColorId = 1,DailyPrice = 3000,Description = "Otomatik şanzıman 7 ileri"},
                new Car(){Id = 2,BrandId = 3,ModelYear = 2018,ColorId = 3,DailyPrice = 3500,Description = "Otomatik şanzıman 7 ileri"},
                new Car(){Id = 3,BrandId = 2,ModelYear = 2015,ColorId = 2,DailyPrice = 2000,Description = "Manual şanzıman 5 ileri"},
                new Car(){Id = 4,BrandId = 1,ModelYear = 2015,ColorId = 1,DailyPrice = 2300,Description = "Manual şanzıman 5 ileri"},
                new Car(){Id = 5,BrandId = 2,ModelYear = 2020,ColorId = 3,DailyPrice = 4000,Description = "Otomatik şanzıman 6 ileri"}

            };
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {

            return _cars.SingleOrDefault(filter.Compile());
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return filter == null ? _cars.ToList() : _cars.Where(filter.Compile()).ToList();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine(car.BrandId.ToString() + " marka Id'li araba sisteme eklendi");

        }

        public void Delete(Car car)
        {
            _cars.Remove(_cars.SingleOrDefault(c => c.Id == car.Id));
            Console.WriteLine(car.BrandId.ToString() + " marka Id'li araba sistemden silindi");

        }

        public void Update(Car car)
        {
            Car carToUpdate=_cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            Console.WriteLine(car.BrandId.ToString() + " marka Id'li araba sistemde güncellendi");
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
