using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.DTOs.Response;

namespace SISARA.Application.UseCases.Users.Queries.GetAllQuery
{
    public class GetAllUserQuery : IRequest<BaseResponse<IEnumerable<GetAllUserResponseDto>>>
    {
    }
}
