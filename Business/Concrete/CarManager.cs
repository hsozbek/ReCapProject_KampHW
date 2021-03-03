using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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
       

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
            
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            
            
            _carDal.Add(car);
            return new SuccessResult(Messages.Car.Added);
            
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

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id),Messages.Car.GetById);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.Car.Details);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),
                Messages.Car.GetAll);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id),
                Messages.Car.GetAll); 
        }

        public IResult Update(Car car)
        {


            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Update(car);
            return new SuccessResult(Messages.Car.Updated);
        }

    }
}
