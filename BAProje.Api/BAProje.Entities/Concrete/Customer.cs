using BAProje.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAProje.Entities.Concrete
{
    public class Customer:ITable
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        
        public Cart Cart { get; set; }
    }
}
