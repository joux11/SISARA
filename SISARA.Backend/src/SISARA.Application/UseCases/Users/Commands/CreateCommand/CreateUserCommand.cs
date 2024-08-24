using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.DTOs.Request;


namespace SISARA.Application.UseCases.Users.Commands.CreateCommand
{
    public class CreateUserCommand : RegisterUserRequestDto,IRequest<BaseResponse<bool>>
    {

    }
}
