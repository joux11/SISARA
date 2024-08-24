using SISARA.Domain.Entities;

namespace SISARA.Application.DTOs.Response
{
    public class GetAllUserResponseDto
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
        public uint? RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
