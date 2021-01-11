using BAProje.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAProje.Entities.Concrete
{
    public class ProductOfCart:ITable
    {
        
        public int Id { get; set; }
        public int RealProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int OrderQuantity { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
