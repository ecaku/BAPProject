namespace BAProjeFront.Models{
    public class ProductOfCart{
        public int Id { get; set; }
        public int RealProductId{get;set;}
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int OrderQuantity { get; set; }
        public int? CartId { get; set; }
        public Cart Cart { get; set; }
    }
}