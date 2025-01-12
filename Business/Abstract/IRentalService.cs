﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetById(int id);
        IDataResult<List<Rental>> GetByCarId(int carId);

        //IDataResult<List<Rental>> GetAll();
        //IDataResult<Rental> GetById(int rentalId);
        //IResult Add(Rental rental);
        //IResult Delete(Rental rental);
        //IResult Update(Rental rental);
        //IDataResult<List<Rental>> GetAllByCarId(int carId);
        //IDataResult<Rental> GetLastByCarId(int carId);
        //IDataResult<List<Rental>> GetAllByCustomerId(int customerId);
        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();
        //IResult IsDelivered(Rental rental);
        //IResult IsRentable(Rental rental);
    }
}
