using FluentValidation;
using StorageProject.Application.DTOs.Product;

namespace StorageProject.Application.Validators
{
    public class ProductValidator : AbstractValidator<CreateProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Field Name is required")
                .WithErrorCode("400")
                .Length(3,100);

            RuleFor(x => x.Description)
                .Length(0, 250)
                .WithMessage("Field Description must have a maximum of 250 characters");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("Field Quantity is required")
                .LessThanOrEqualTo(int.MaxValue);

            RuleFor(x => x.BrandId)
                .NotEmpty()
                .WithMessage("Field Brand is required")
                .WithErrorCode("400");

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("Field Category is required")
                .WithErrorCode("400");
        }
    }
}
