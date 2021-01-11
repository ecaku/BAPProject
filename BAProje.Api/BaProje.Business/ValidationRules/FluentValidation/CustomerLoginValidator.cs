using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.Business.ValidationRules.FluentValidation
{
    public class CustomerLoginValidator : AbstractValidator<CustomerLoginDto>
    {
        public CustomerLoginValidator()
        {
            RuleFor(I => I.CustomerName).NotEmpty().WithMessage("Kullanıcı Adı Girilmedi");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Şifre girilmedi");
           
        }
    }
}
