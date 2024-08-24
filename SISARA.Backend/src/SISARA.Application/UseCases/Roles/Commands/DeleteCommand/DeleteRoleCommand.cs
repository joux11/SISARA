using MediatR;
using SISARA.Application.Common.Base;

namespace SISARA.Application.UseCases.Roles.Commands.DeleteCommand
{
    public class DeleteRoleCommand : IRequest<BaseResponse<bool>>
    {
        public uint Id { get; set; }
    }
}
