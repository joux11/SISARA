using SISARA.Domain.ValueObjects;

namespace SISARA.Application.DTOs.Request
{
    public class RegisterUserRequestDto
    {
        public string? Identification { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Cellphone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
