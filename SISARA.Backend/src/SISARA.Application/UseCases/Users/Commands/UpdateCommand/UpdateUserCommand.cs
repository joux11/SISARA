using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.DTOs.Request;

namespace SISARA.Application.UseCases.Users.Commands.UpdateCommand
{
    public class UpdateUserCommand : UpdateUserRequestDto, IRequest<BaseResponse<bool>>
    {
    }
}
