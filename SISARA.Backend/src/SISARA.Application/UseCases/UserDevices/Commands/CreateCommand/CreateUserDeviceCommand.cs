using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.DTOs.Request;

namespace SISARA.Application.UseCases.UserDevices.Commands.CreateCommand;

public class CreateUserDeviceCommand : RegisterUserDeviceRequestDto,IRequest<BaseResponse<bool>>
{
    
}
