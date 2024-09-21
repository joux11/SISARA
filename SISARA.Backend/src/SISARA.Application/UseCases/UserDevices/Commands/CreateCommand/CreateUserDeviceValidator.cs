using FluentValidation;
using SISARA.Application.Interfaces;

namespace SISARA.Application.UseCases.UserDevices.Commands.CreateCommand;

public class CreateUserDeviceValidator : AbstractValidator<CreateUserDeviceCommand>
{
	public CreateUserDeviceValidator(IUserRepository userRepository)
	{
		RuleFor(x => x.DeviceId)
			.NotEmpty().WithMessage("El ID del dispositivo no debe estar vacio")
			.NotNull().WithMessage("El ID del dispositivo no debe ser nulo");

		RuleFor(x => x.Brand)
			.NotEmpty().WithMessage("La marca no debe estar vacio");
			
		RuleFor(x => x.Model)
			.NotEmpty().WithMessage("El modelo no debe estar vacio");
		RuleFor(x => x.UserId)
			.NotEmpty().WithMessage("El ID del usuario no debe estar vacio")
			.NotNull().WithMessage("El ID del usuario no debe ser nulo")
			.Must((userId)=> userId !=0).WithMessage("El ID del usuario no debe ser 0")
			.MustAsync(async (userId,cancellation) => 
			{				
				var user = await userRepository.UserById(userId!.Value);
				return user is not null;	
			}).WithMessage("No existe un Usuario con UserId");		
	}
	
}
