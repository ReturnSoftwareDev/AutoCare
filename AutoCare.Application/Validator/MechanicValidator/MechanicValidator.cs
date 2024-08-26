using FluentValidation;
using AutoCare.Domain.Entities;

namespace AutoCare.Application.Validators
{
    public class MechanicValidator : AbstractValidator<Mechanic>
    {
        public MechanicValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("İsim alanı gereklidir.")
                .Length(1, 100).WithMessage("İsim 1 ile 100 karakter arasında olmalıdır.");

            RuleFor(m => m.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası gereklidir.")
                .Length(1, 15).WithMessage("Telefon numarası 1 ile 15 karakter arasında olmalıdır.");

            RuleFor(m => m.Email)
                .EmailAddress().WithMessage("Geçersiz e-posta formatı.")
                .Length(0, 100).WithMessage("E-posta 100 karakterden uzun olmamalıdır.");

            RuleFor(m => m.City)
                .NotEmpty().WithMessage("Şehir alanı gereklidir.")
                .Length(1, 50).WithMessage("Şehir 1 ile 50 karakter arasında olmalıdır.");

            RuleFor(m => m.Discrict)
                .NotEmpty().WithMessage("Semt alanı gereklidir.")
                .Length(1, 50).WithMessage("Semt 1 ile 50 karakter arasında olmalıdır.");

            RuleFor(m => m.Neighborhood)
                .NotEmpty().WithMessage("Mahalle alanı gereklidir.")
                .Length(1, 50).WithMessage("Mahalle 1 ile 50 karakter arasında olmalıdır.");

        }
    }
}
