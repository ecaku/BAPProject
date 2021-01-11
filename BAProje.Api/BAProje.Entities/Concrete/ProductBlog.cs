using BAProje.Entities.Interfaces;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAProje.Entities.Concrete
{
    public class ProductBlog:ITable
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int StockQuantity { get; set; }
        public double Price { get; set; }
        public string ProductDescription { get; set; }
        public string ImagePath{ get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;
        
        public List<Comment> Comments { get; set; }
    }
}
