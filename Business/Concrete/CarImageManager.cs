using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(List<IFormFile> imageFiles, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageCountFiveorMore(carImage.CarId, imageFiles.Count), CheckCarImageCountZero(imageFiles.Count));

            if (result != null)
            {
                return result;
            }

            var webRootPath = Path.Combine(Environment.CurrentDirectory, "wwwroot");

            foreach (var image in imageFiles)
            {
                if (image.Length > 0)
                {
                    string extension = Path.GetExtension(image.FileName);
                    string imageName = string.Format("{0}{1}", Guid.NewGuid().ToString(), extension);
                    string imageFolder = Path.Combine(webRootPath, "Images");
                    string imagePath = Path.Combine(imageFolder, imageName);
                    string webImagePath = string.Format("/Images/{0}", imageName);

                    if (!Directory.Exists(imageFolder))
                    {
                        Directory.CreateDirectory(imageFolder);
                    }

                    using (FileStream fileStream = File.Create(imagePath))
                    {
                        image.CopyTo(fileStream);
                        fileStream.Flush();
                    }

                    _carImageDal.Add(new CarImage { ImagePath = webImagePath, CarId = carImage.CarId, Date = DateTime.Now });
                }

            }

            return new SuccessResult(Messages.CarImage.Added);

        }

        public IResult Delete(CarImage carImage)
        {
            var image = GetById(carImage.Id).Data;
            if (image == null)
            {
                return new ErrorResult("Resim bulunamadı");
            }

            string imagePath = string.Format("{0}{1}", "wwwroot", image.ImagePath);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }


            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImage.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImage.GetAll);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id), Messages.CarImage.GetById);
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile imageFile, CarImage carImage)
        {
            var oldImage = GetById(carImage.Id).Data;
            if (oldImage == null)
            {
                return new ErrorResult("Resim bulunamadı");
            }
            string oldImagePath = string.Format("{0}{1}", "wwwroot", oldImage.ImagePath); 

            if (File.Exists(oldImagePath))
            {
                File.Delete(oldImagePath);
            }
            var webRootPath = Path.Combine(Environment.CurrentDirectory,"wwwroot");


            string extension = Path.GetExtension(imageFile.FileName);
            string imageName = string.Format("{0}{1}", Guid.NewGuid().ToString(), extension);
            string imageFolder = Path.Combine(webRootPath, "Images");
            string imagePath = Path.Combine(imageFolder, imageName);
            string webImagePath = string.Format("/Images/{0}", imageName);

            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }

            using (FileStream fileStream = File.Create(imagePath))
            {
                imageFile.CopyTo(fileStream);
                fileStream.Flush();
            }

            carImage.ImagePath = webImagePath;
            

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImage.Updated);
        }

        private IResult CheckCarImageCountFiveorMore(int carId, int imageFilesCount)
        {
            var result = GetAllByCarId(carId);
            if (result.Data.Count + imageFilesCount <= 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Her araca ait en çok toplam 5 resim bulunmalıdır.");
        }

        private IResult CheckCarImageCountZero(int imageFilesCount)
        {
            if (imageFilesCount != 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Lütfen resim ekleyiniz");
        }

    }
}
