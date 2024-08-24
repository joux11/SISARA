using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.DTOs.Response;

namespace SISARA.Application.UseCases.Users.Queries.GetByIdQuery
{
    public class GetUserByIdQuery : IRequest<BaseResponse<GetUserResponseDto>>
    {
        public uint Id { get; set; }
    }
}
