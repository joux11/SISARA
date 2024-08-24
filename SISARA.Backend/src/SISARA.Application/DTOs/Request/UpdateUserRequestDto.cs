namespace SISARA.Application.DTOs.Request
{
    public class UpdateUserRequestDto
    {
        public uint Id { get; set; }
        public string? Identification { get; set; }
        public string? Name { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? Cellphone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        //public byte[]? Photo { get; set; }
        public bool? IsActive { get; set; }
        public uint? RoleId { get; set; }        


    }
}
