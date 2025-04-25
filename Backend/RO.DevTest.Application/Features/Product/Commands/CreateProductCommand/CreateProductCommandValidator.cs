using FluentValidation;

namespace RO.DevTest.Application.Features.Product.Commands.CreatProductCommand
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(cpau => cpau.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo nome precisa ser preenchido.");
            RuleFor(cpau => cpau.Price)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("O campo preço deve ser maior do que zero.");
            RuleFor(cpau => cpau.Stock)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("O campo estoque não pode conter valores negativos.");
        }
    }
}
