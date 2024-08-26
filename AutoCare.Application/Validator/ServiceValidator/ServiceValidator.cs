using AutoCare.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Validator.ServiceValidator;
public class ServiceValidator : AbstractValidator<Service>
{
    public ServiceValidator()
    {
        RuleFor(m => m.Name)
            .NotEmpty().WithMessage("İsim alanı gereklidir.")
            .Length(1, 100).WithMessage("İsim 1 ile 100 karakter arasında olmalıdır.");

    }
}
