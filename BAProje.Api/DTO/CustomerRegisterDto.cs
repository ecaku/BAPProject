using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CustomerRegisterDto:IDto
    {
        public string CustomerName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
