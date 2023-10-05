using Catalog.API.Application.Dtos;
using FluentValidation;

namespace Catalog.API.Application.Validators;

public class ProductForAddValidator : AbstractValidator<ProductForAddDto>
{
    public ProductForAddValidator()
    {
        // RuleFor(p=> p.Name).NotEmpty().WithMessage("Name can not be empty.")
        // .MinimumLength(3).WithMessage("Custom Message 1")
        // .MaximumLength(50).WithMessage("Custom Message 2");

        RuleFor(p => p.Name)
                        .NotEmpty()
                        .MinimumLength(3)
                        .MaximumLength(50);

        //? Other Properties
    }
}
