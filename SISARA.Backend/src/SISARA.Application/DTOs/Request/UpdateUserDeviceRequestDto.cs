namespace SISARA.Application.DTOs.Request;

public class UpdateUserDeviceRequestDto
{
	public uint Id { get; set; }
	public string? DeviceId { get; set; }
	public string? Brand { get; set; }
	public string? Model { get; set; }	
}
