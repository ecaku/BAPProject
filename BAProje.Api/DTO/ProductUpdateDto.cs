using DTO.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ProductUpdateDto:IDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public string ProductDescription { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}
