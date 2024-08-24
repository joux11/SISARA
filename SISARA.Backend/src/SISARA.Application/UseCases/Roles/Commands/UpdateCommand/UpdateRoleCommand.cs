using MediatR;
using SISARA.Application.Common.Base;

namespace SISARA.Application.UseCases.Roles.Commands.UpdateCommand
{
    public class UpdateRoleCommand : IRequest<BaseResponse<bool>>
    {
        public uint Id { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
