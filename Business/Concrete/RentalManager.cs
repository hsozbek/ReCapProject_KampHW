using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private IValidator<Rental> _validator;

        public RentalManager(IRentalDal rentalDal, IValidator<Rental> validator)
        {
            _rentalDal = rentalDal;
            _validator = validator;
        }


        public IResult Add(Rental rental)
        {
            foreach (var checkRental in GetByCarId(rental.CarId).Data)
            {
               var errors = ValidationTool.Validate(_validator, checkRental);
               var failure = errors.SingleOrDefault(e => e.ErrorCode == "RDATE001");
               if (failure!=null)
               {
                   return new ErrorResult(Messages.Rental.CarUnavailable);
               }
               
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Rental.Added);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Rental.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Rental.GetAll);
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
           return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id),Messages.Rental.GetById);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Rental.Updated);
        }
    }
}
