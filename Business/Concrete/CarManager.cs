using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.Utilities;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;


namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private IValidator<Car> _validator;

        public CarManager(ICarDal carDal, IValidator<Car> validator)
        {
            _carDal = carDal;
            _validator = validator;
        }


        public IResult Add(Car car)
        {
            var errors = ValidationTool.Validate(_validator, car);
            var cnt = errors.Count();
            if (cnt > 0)
            {
                return new ErrorResult(string.Join("\n", errors));
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.Car.Added);
            Console.WriteLine("{0} Added", car.Name);
        }

        public IResult Delete(Car car)
        {

            _carDal.Delete(car);
            return new SuccessResult(Messages.Car.Deleted);

        }



        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Car.GetAll);
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == Id),Messages.Car.GetById);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.Car.Details);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == Id),
                Messages.Car.GetAll);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == Id),
                Messages.Car.GetAll); 
        }

        public IResult Update(Car car)
        {
            var errors = ValidationTool.Validate(_validator, car);
            if (errors.Count()>0)
            {
                return new ErrorResult(string.Join("\n", errors));
            }
            
            
            _carDal.Update(car);
            return new SuccessResult(Messages.Car.Updated);
        }

    }
}
