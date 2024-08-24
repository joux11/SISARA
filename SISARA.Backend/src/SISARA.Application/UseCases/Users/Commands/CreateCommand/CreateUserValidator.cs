using FluentValidation;
using SISARA.Application.Interfaces;

namespace SISARA.Application.UseCases.Users.Commands.CreateCommand
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {

        public CreateUserValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Identification)
                .NotEmpty().WithMessage("La Cedula o Identificacion es requerida.")
                .NotNull().WithMessage("No debe ser Nulo")

                .MinimumLength(10).WithMessage("La cedula debe tener 10 Digitos.")
                .MaximumLength(10).WithMessage("La Cedula debe tener 10 Digitos")
                .Must(IsValidIdentification).WithMessage("La Cedula no es Valida.")
                .MustAsync(async (identification, cancellation) =>
                {
                    var user = await userRepository.UserByIdentification(identification);
                    return user == null;
                }).WithMessage("La Cedula ya se encuentra registrada");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El Nombre es requerido.")
                .NotNull().WithMessage("EL Nombre no debe ser Nulo.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El Apellido es requerido.")
                .NotNull().WithMessage("El Apellido no puede ser Nulo");

            RuleFor(x => x.Cellphone)
                .NotEmpty().WithMessage("El Numero de Celular es requerido.")
                .NotNull().WithMessage("El Numero de celular no debe ser Nulo")
                .MinimumLength(10).WithMessage("El Numero de celular debe tener 10 Digitos.")
                .MaximumLength(10).WithMessage("El Numero de celular debe tener 10 Digitos");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("El correo electrónico no tiene un formato válido.")
                .MustAsync(async (email, cancellation) =>
                {
                    var user = await userRepository.UserByEmail(email);
                    return user == null;
                }).WithMessage("El Email ya se encuentra registrado");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.");


        }
        public bool IsValidIdentification(string identification)
        {
            bool isValid = false;

            if (!int.TryParse(identification, out _))
            {
                return false;
            }

            int thirdDigit = int.Parse(identification.Substring(2, 1));
            if (thirdDigit < 6)
            {
                int[] validCoefficient = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
                int checkDigit = int.Parse(identification.Substring(9, 1));
                int sum = 0;
                for (int i = 0; i < 9; i++)
                {
                    int digit = int.Parse(identification.Substring(i, 1)) * validCoefficient[i];
                    sum += (digit % 10) + (digit / 10);
                }
                int modulo = sum % 10;
                int calculatedCheckDigit = (modulo == 0) ? 0 : 10 - modulo;

                if (checkDigit == calculatedCheckDigit)
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}
