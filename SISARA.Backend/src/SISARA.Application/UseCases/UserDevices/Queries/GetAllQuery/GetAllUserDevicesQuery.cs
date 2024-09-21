using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Domain.Entities;

namespace SISARA.Application.UseCases.UserDevices.Queries.GetAllQuery;

public class GetAllUserDevicesQuery : IRequest<BaseResponse<IEnumerable<UserDevice>>>
{
    
}
