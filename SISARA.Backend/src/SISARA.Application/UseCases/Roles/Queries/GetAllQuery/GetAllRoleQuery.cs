using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Domain.Entities;

namespace SISARA.Application.UseCases.Roles.Queries.GetAllQuery
{
    public class GetAllRoleQuery : IRequest<BaseResponse<List<Role>>>
    {
    }
}
