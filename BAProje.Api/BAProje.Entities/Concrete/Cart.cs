using BAProje.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAProje.Entities.Concrete
{
    public class Cart : ITable
    {
        public int Id { get; set; }
        public int ProductQuantity { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<ProductOfCart> ProductOfCart { get; set; }
    }
}
