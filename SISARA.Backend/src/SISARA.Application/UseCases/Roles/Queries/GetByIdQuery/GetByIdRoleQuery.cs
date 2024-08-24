using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Domain.Entities;

namespace SISARA.Application.UseCases.Roles.Queries.GetByIdQuery
{
    public class GetByIdRoleQuery : IRequest<BaseResponse<Role>>
    {
        public uint Id { get; set; }
    }
}
