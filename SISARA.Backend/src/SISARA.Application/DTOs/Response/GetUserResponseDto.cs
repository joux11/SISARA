
namespace SISARA.Application.DTOs.Response
{
    public class GetUserResponseDto
    {
        public uint Id { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? SecondName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string? SecondLastName { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
