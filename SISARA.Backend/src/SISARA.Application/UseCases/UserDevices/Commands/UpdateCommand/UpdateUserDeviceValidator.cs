using FluentValidation;

namespace SISARA.Application.UseCases.UserDevices.Commands.UpdateCommand;

public class UpdateUserDeviceValidator : AbstractValidator<UpdateUserDeviceCommand>
{
	public UpdateUserDeviceValidator()
	{
		RuleFor(x => x.DeviceId)
			.NotEmpty().WithMessage("El ID del dispositivo no debe estar vacio")
			.NotNull().WithMessage("El ID del dispositivo no debe ser nulo");

		RuleFor(x => x.Brand)
			.NotEmpty().WithMessage("La marca no debe estar vacio");
			
		RuleFor(x => x.Model)
			.NotEmpty().WithMessage("El modelo no debe estar vacio");
	}
}
