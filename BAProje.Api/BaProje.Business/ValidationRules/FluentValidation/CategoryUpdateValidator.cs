using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.Business.ValidationRules.FluentValidation
{
    class CategoryUpdateValidator:AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(I => I.CategoryName).NotEmpty().WithMessage("Değiştireceğiniz Kategorinin Yeni Adını Girmediniz");
            
        }
    }
}
