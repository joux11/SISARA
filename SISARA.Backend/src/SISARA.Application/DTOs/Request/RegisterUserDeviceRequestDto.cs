namespace SISARA.Application.DTOs.Request;

public class RegisterUserDeviceRequestDto
{
    public string? DeviceId { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public uint? UserId { get; set; }

}
