using BAProje.Entities.Concrete;
using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CustomerDto:IDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public Cart Cart { get; set; }

    }
}
