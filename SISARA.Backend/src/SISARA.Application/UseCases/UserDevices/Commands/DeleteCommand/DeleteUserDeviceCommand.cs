using MediatR;
using SISARA.Application.Common.Base;

namespace SISARA.Application.UseCases.UserDevices.Commands.DeleteCommand;

public class DeleteUserDeviceCommand : IRequest<BaseResponse<bool>>
{
	public uint Id { get; set; }
}
