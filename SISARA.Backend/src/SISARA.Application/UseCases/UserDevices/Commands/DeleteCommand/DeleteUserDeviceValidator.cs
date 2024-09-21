using FluentValidation;

namespace SISARA.Application.UseCases.UserDevices.Commands.DeleteCommand;

public class DeleteUserDeviceValidator : AbstractValidator<DeleteUserDeviceCommand>
{
	public DeleteUserDeviceValidator()
	{
		RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es requerido!").NotNull().WithMessage("El Id no debe ser Nulo");
	}
}
