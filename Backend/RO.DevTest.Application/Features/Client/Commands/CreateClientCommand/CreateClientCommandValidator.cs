using FluentValidation;

namespace RO.DevTest.Application.Features.Client.Commands.CreateClientCommand
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(cpau => cpau.ClientName)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo nome precisa ser preenchido.");
        }
    }
}
