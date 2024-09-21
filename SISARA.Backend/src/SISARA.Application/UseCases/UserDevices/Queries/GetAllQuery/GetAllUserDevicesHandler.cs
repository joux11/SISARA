using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.Interfaces;
using SISARA.Domain.Entities;

namespace SISARA.Application.UseCases.UserDevices.Queries.GetAllQuery;

public class GetAllUserDevicesHandler : IRequestHandler<GetAllUserDevicesQuery, BaseResponse<IEnumerable<UserDevice>>>
{
    private readonly IUserDeviceRepository _userDeviceRepository;
    public GetAllUserDevicesHandler(IUserDeviceRepository userDeviceRepository)
    {
        _userDeviceRepository = userDeviceRepository;
    }
    public async Task<BaseResponse<IEnumerable<UserDevice>>> Handle(GetAllUserDevicesQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<UserDevice>>();
        try
        {
            var userDevices = await _userDeviceRepository.ListUserDevices();
            if(userDevices is not null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa";
                response.Data = userDevices;
                return response;
            }
            
        }
        catch (Exception ex)
        {            
            response.Message = ex.Message;
        }
        return response;
    }
}
