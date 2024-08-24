using FluentValidation;

namespace SISARA.Application.UseCases.Roles.Commands.CreateCommand
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El Nombre del rol es requerido").NotNull().WithMessage("El Nombre del Rol no debe ser Nulo");
        }
    }
}
