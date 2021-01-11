using System.Collections.Generic;

namespace BAProjeFront.Models{
    public class Cart{
        public int Id { get; set; }
        public int ProductQuantity { get; set; }
        public int CustomerId { get; set; }
        public List<ProductOfCart> productOfCart{get;set;}
        
    }
}