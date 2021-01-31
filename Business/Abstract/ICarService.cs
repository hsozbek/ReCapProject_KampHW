﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int Id);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
