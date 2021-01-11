using System;

namespace BAProjeFront.Models{
    public class RecomendedProductListModel{
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string ProductDescription { get; set; }
        public int StokQuantity { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public DateTime PostedTime { get; set; }
    }
}