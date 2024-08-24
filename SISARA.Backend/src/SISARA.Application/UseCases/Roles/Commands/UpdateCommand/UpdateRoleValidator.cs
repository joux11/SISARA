using FluentValidation;

namespace SISARA.Application.UseCases.Roles.Commands.UpdateCommand
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es requerido").NotNull();

        }
    }
}
