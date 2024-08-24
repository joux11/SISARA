using MediatR;
using SISARA.Application.Common.Base;

namespace SISARA.Application.UseCases.Users.Commands.DeleteCommand
{
    public class DeleteUserCommand : IRequest<BaseResponse<bool>>
    {
        public uint Id { get; set; }
    }
}
