﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //DTO : Data Transformation Object
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string ModelYear { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int FindexPoint { get; set; }
    }
}
