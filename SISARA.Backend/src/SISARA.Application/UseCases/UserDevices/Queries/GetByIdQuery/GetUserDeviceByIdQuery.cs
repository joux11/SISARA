using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Domain.Entities;

namespace SISARA.Application.UseCases.UserDevices.Queries.GetByIdQuery;

public class GetUserDeviceByIdQuery : IRequest<BaseResponse<UserDevice>>
{
    public uint Id {get; set; }
}
