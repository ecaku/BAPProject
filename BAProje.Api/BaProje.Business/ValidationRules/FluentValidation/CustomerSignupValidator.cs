using DTO;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.Business.ValidationRules.FluentValidation
{
    public class CustomerSignupValidator:AbstractValidator<CustomerRegisterDto>
    {
        public CustomerSignupValidator()
        {
            RuleFor(I => I.Email).EmailAddress().WithMessage("Email formatına uygun bir değer girilmedi");
            RuleFor(I => I.CustomerName).NotNull().WithMessage("Kullanıcı adı girilmedi");
            RuleFor(I => I.Password).NotNull().WithMessage("Kullanıcı adı girilmedi");
            
        }
    }
}
