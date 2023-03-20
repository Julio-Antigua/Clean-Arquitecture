using FluentValidation;

namespace CleanArquitecture.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");

            RuleFor(c => c.Lastname)
                .NotNull().WithMessage("{Apellido} no puede ser nulo");
        }
    }
}
