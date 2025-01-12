﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        private ICustomerService _customerService;
        private ICarService _carService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }

        
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfCarRented(rental),
               FindexPointCheck(rental.CustomerId, rental.CarId));


            if (result !=null)
            {
                return new ErrorResult(Messages.RentedCarAlreadyExists);
            }
            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);
        }

        [SecuredOperation("rental.delete,admin")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentalId == id));
        }
        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails());
        }

        [SecuredOperation("rental.update,admin")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }

        private IResult CheckIfCarRented(Rental rental)
        {
            var result = _rentalDal.GetAll(
                r => r.CarId == rental.CarId &&
                (r.ReturnDate == null || r.ReturnDate < DateTime.Now)
                ).Any();

            if (result)
            {
                return new ErrorResult(Messages.CarAlreadyRented);
            }

            return new SuccessResult();
        }


        private IResult FindexPointCheck(int customerId, int carId)
        {
            var customer = _customerService.GetById(customerId).Data;

            if (customer.FindexPoint == 0)
            {
                return new ErrorResult(Messages.CustomerFindexPointIsZero);
            }

            var car = _carService.GetById(carId).Data;

            if (customer.FindexPoint < car.FindexPoint)
            {
                return new ErrorResult(Messages.CustomerScoreInvalid);
            }

            customer.FindexPoint = (car.FindexPoint / 2) + customer.FindexPoint;

            _customerService.Update(customer);
            return new SuccessResult();
        }
        //public IDataResult<List<Rental>> GetAllByCarId(int carId)
        //{
        //    return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        //}

        //public IDataResult<Rental> GetLastByCarId(int carId)
        //{
        //    return new SuccessDataResult<Rental>(_rentalDal.GetAll(r => r.CarId == carId).LastOrDefault());
        //}

        //public IDataResult<List<Rental>> GetAllByCustomerId(int customerId)
        //{
        //    return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerId == customerId));
        //}
        //public IResult IsDelivered(Rental rental)
        //{
        //    var result = this.GetAllByCarId(rental.CarId).Data.LastOrDefault();
        //    if (result == null || result.ReturnDate != default)
        //        return new SuccessResult();
        //    return new ErrorResult();

        //}
        //public IResult IsRentable(Rental rental)
        //{
        //    var result = this.GetAllByCarId(rental.CarId).Data.LastOrDefault();
        //    if (IsDelivered(rental).Success || (rental.RentStartDate > result.RentEndDate && rental.RentStartDate >= DateTime.Now))
        //    {
        //        return new SuccessResult();
        //    }
        //    return new ErrorResult();
        //}
    }
}
