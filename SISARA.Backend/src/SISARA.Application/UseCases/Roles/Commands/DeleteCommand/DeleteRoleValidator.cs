using FluentValidation;

namespace SISARA.Application.UseCases.Roles.Commands.DeleteCommand
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es requerido!").NotNull().WithMessage("El Id no debe ser Nulo");
        }
    }
}
