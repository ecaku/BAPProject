using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.Business.ValidationRules.FluentValidation
{
    public class ProductAddValidator:AbstractValidator<ProductAddDto>
    {
        public ProductAddValidator()
        {
            RuleFor(I => I.CategoryId).NotEmpty().WithMessage("Kategori Id Seçilmedi");
            RuleFor(I => I.ProductName).NotEmpty().WithMessage("ProductName Girilmedi");
            RuleFor(I => I.StockQuantity).NotEmpty().InclusiveBetween(0, int.MaxValue).WithMessage("Geçerli bir Stok Sayısı Girin");
            RuleFor(I => I.Price).NotEmpty().InclusiveBetween(0, int.MaxValue).WithMessage("Geçerli Bir Fiyat Değerin Girin");
            RuleFor(I => I.ProductDescription).Length(0, 3000).WithMessage("Girilen Açıklama Fazla Uzun");
        }
    }
}
