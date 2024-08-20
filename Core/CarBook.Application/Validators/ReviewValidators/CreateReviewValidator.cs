using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
	public class CreateReviewValidator:AbstractValidator<CreateReviewCommand>
	{
        public CreateReviewValidator()
        {
            RuleFor(x=>x.CustomerName).NotEmpty().WithMessage("Lütfen Müşteri adını boş geçmeyiniz!");
            RuleFor(x=>x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapınız!");
            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz!");
            RuleFor(x => x.Comment).MinimumLength(25).NotEmpty().WithMessage("Lütfen yorum değerini en az 25 karakter olarak ayarlayınız!");
            RuleFor(x => x.Comment).MaximumLength(500).NotEmpty().WithMessage("Lütfen yorum değerini en fazla 500 karakter olarak ayarlayınız!");
        }
    }
}
