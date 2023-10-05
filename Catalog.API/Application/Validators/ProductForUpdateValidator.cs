using Catalog.API.Application.Dtos;
using FluentValidation;

namespace Catalog.API.Application.Validators;

public class ProductForUpdateValidator : AbstractValidator<ProductForUpdateDto>
{
    public ProductForUpdateValidator()
    {
        RuleFor(p => p.Name)
                        .NotEmpty()
                        .MinimumLength(3)
                        .MaximumLength(50);

        //? Other Properties
    }
}
