using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(List<IFormFile> imageFiles, CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IResult Update(IFormFile imageFile ,CarImage carImage);
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}
