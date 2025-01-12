﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("car/{carId}")]
        public IActionResult GetAllByCarId(int carId)
        {
            var result = _carImageService.GetAllByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get( int id) 
        {
            var result = _carImageService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile image, [FromForm] CarImage carImage)
        {

            var result = _carImageService.Add(image, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile image, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(image, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
    //[Route("api/[controller]")]
    //[ApiController]
    //public class CarImagesController : ControllerBase
    //{
    //    ICarImageService _carImageService;

    //    public CarImagesController(ICarImageService carImageService)
    //    {
    //        _carImageService = carImageService;
    //    }

    //    [HttpPost("add")]
    //    public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
    //    {
    //        var result = _carImageService.Add(file, carImage);
    //        if (result.Success)
    //        {
    //            return Ok(result);
    //        }
    //        return BadRequest(result);
    //    }

    //    [HttpDelete("delete")]
    //    public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
    //    {

    //        var carImage = _carImageService.Get(Id).Data;
    //        var result = _carImageService.Delete(carImage);
    //        if (result.Success)
    //        {
    //            return Ok(result);
    //        }
    //        return BadRequest(result);
    //    }

    //    [HttpPut("update")]
    //    public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int Id)
    //    {
    //        var carImage = _carImageService.Get(Id).Data;
    //        var result = _carImageService.Update(file, carImage);
    //        if (result.Success)
    //        {
    //            return Ok(result);
    //        }
    //        return BadRequest(result);
    //    }

    //    [HttpGet("getbyid")]
    //    public IActionResult GetById([FromForm(Name = ("Id"))] int Id)
    //    {
    //        var result = _carImageService.Get(Id);
    //        if (result.Success)
    //        {
    //            return Ok(result);
    //        }
    //        return BadRequest(result);
    //    }

    //    [HttpGet("getall")]
    //    public IActionResult GetAll()
    //    {
    //        var result = _carImageService.GetAll();
    //        if (result.Success)
    //        {
    //            return Ok(result);
    //        }
    //        return BadRequest(result);
    //    }

    //[HttpGet("getimagesbycarid")]
    //public IActionResult GetImagesByCarId(int carId)
    //{
    //    var result = _carImageService.GetImagesByCarId(carId);
    //    if (result.Success)
    //    {
    //        return Ok(result);
    //    }
    //    return BadRequest(result.Message);
    //}
    //}
}
