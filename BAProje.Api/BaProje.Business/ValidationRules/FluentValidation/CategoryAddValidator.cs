using DTO;
using FluentValidation;
using Stripe.Radar;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.Business.ValidationRules.FluentValidation
{
    public class CategoryAddValidator:AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(I => I.CategoryName).NotEmpty().WithMessage("Yeni Eklenecek Kategori Adı Girilmedi");
        }
    }
}
