using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.DTOs.Request;

namespace SISARA.Application.UseCases.UserDevices.Commands.UpdateCommand;

public class UpdateUserDeviceCommand : UpdateUserDeviceRequestDto,IRequest<BaseResponse<bool>>
{
	
}
