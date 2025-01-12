﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            //Oracle, SQL Server, Postgres, MongoDb
            _cars = new List<Car> {
            new Car {Id = 1, BrandId = 1, ColorId = 1, DailyPrice=350, Description = "Arazi Aracı", ModelYear = "2012",CarName= "Volkswagen Amarok"},
            new Car {Id = 2, BrandId = 2, ColorId = 2, DailyPrice=500, Description = "Yük Taşıma Aracı", ModelYear = "2000",CarName= "Scanıa R450"},
            new Car {Id = 3, BrandId = 3, ColorId = 3, DailyPrice=300, Description = "Yolcu Taşıma Aracı", ModelYear = "2010",CarName= "Mercedes Travego"},
            new Car {Id = 4, BrandId = 1, ColorId = 2, DailyPrice=150, Description = "Günlük Kullanım Arabası", ModelYear = "2020",CarName= "Volkswagen Golf"},
            new Car {Id = 5, BrandId = 2, ColorId = 3, DailyPrice=400, Description = "Düğün Arabası", ModelYear = "2008",CarName= "Audi A6"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //LINQ - Language Integrated Query
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int Id)
        {
            return _cars.FirstOrDefault(c => c.Id == Id);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        //public List<Car> GetById(int Id)
        //{
        //    return _cars.Where(c => c.Id == Id).ToList();
        //}

        public void Update(Car car)
        {
            //Gönderdiğim Car id'sine sahip olan listedeki car'ı bul demek
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
