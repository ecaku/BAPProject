using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class AddProductToCartDto:IDto
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
    }
}
