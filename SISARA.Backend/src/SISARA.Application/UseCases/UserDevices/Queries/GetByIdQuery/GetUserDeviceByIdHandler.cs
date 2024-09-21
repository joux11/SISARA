using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.Interfaces;
using SISARA.Domain.Entities;

namespace SISARA.Application.UseCases.UserDevices.Queries.GetByIdQuery;

public class GetUserDeviceByIdHandler : IRequestHandler<GetUserDeviceByIdQuery,BaseResponse<UserDevice>>
{
    private readonly IUserDeviceRepository _userDeviceRepository;
    public GetUserDeviceByIdHandler(IUserDeviceRepository userDeviceRepository){
        _userDeviceRepository = userDeviceRepository;
    }

    public async Task<BaseResponse<UserDevice>> Handle(GetUserDeviceByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<UserDevice>();
        try
        {
            var userDevice = await _userDeviceRepository.UserDeviceById(request.Id);
            if(userDevice is null)
            {
                response.IsSuccess = false;
                response.Message = "El dispositivo no existe";
                return response;
            }
            response.IsSuccess = true;
            response.Message = "Consulta Exitosa!";
            response.Data = userDevice;
        }
        catch (Exception ex)
        {            
            response.Message = ex.Message;
        }        
        return response;
    }
}
