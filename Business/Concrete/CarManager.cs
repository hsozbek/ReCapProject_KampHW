using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Utilities;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;


namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private IValidator<Car> _validator;

        public CarManager(ICarDal carDal,IValidator<Car> validator)
        {
            _carDal = carDal;
            _validator = validator;
        }


        public void Add(Car car)
        {
            try
            {
                ValidationTool.Validate(_validator, car);
                _carDal.Add(car);
                Console.WriteLine("{0} Added", car.Name);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
              
            }
            
            


        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("{0} Deleted", car.Name);
        }

       

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int Id)
        {
            return _carDal.Get(c => c.Id == Id);
        }

        public List<Car> GetCarsByBrandId(int Id)
        {
            return _carDal.GetAll(c => c.BrandId== Id);
        }

        public List<Car> GetCarsByColorId(int Id)
        {
            return _carDal.GetAll(c => c.ColorId == Id);
        }

        public void Update(Car car)
        {
            try
            {
                ValidationTool.Validate(_validator,car);
                _carDal.Update(car);
                Console.WriteLine("{0} Updated", car.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

    }
}
