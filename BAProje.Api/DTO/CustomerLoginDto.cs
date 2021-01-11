using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CustomerLoginDto:IDto
    {
        public string CustomerName { get; set; }
        
        public string Password { get; set; }
    }
}
