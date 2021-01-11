using BAProje.Entities.Concrete;
using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CartDto:IDto
    {
        public int Id { get; set; }
        public int ProductQuantity { get; set; }
        public int CustomerId { get; set; }
        
    }
}
