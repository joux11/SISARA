using MediatR;
using SISARA.Application.Common.Base;

namespace SISARA.Application.UseCases.Roles.Commands.CreateCommand
{
    public class CreateRoleCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
    }
}
