using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BAProjeFront.Models{
    public class ProductListModel{
        
        public int Id { get; set; }
        [Required(ErrorMessage="Urun adı giriniz")]
        [Display(Name="Title")]
        public string ProductName { get; set; }
        [Required(ErrorMessage="Stok adeti giriniz")]
        
        public int StockQuantity { get; set; }
        [Required(ErrorMessage="Kategori Id giriniz")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage="Fiyat giriniz")]
        public double Price { get; set; }
        public string ProductDescription { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
        
    }
}