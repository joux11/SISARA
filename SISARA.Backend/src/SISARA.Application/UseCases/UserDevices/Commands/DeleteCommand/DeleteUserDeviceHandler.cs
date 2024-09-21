using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.Interfaces;

namespace SISARA.Application.UseCases.UserDevices.Commands.DeleteCommand;

public class DeleteUserDeviceHandler : IRequestHandler<DeleteUserDeviceCommand,BaseResponse<bool>>
{
	private readonly IUserDeviceRepository _userDeviceRepository;
	public DeleteUserDeviceHandler(IUserDeviceRepository userDeviceRepository)
	{
		_userDeviceRepository = userDeviceRepository;
	}

	public async Task<BaseResponse<bool>> Handle(DeleteUserDeviceCommand request, CancellationToken cancellationToken)
	{
		var response = new BaseResponse<bool>();
		try
		{
			var userDevice = await _userDeviceRepository.UserDeviceById(request.Id);
			if(userDevice is null)
			{
				response.Message = "No se puede eliminar un Dispositivo que no existe";
				response.IsSuccess = false;
				return response;
			}
			response.Data = await _userDeviceRepository.UserDeviceDelete(userDevice);
			if(response.Data)
			{
				response.IsSuccess = true;
				response.Message = "Dispositivo Eliminado Correctamente";
			}			
				
		}
		catch (Exception ex)
		{
			response.Message = ex.Message;
		}
		return response;
	}
}
