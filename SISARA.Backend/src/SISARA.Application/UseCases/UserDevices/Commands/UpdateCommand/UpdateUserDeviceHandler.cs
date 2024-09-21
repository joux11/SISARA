using AutoMapper;
using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.Interfaces;

namespace SISARA.Application.UseCases.UserDevices.Commands.UpdateCommand;

public class UpdateUserDeviceHandler : IRequestHandler<UpdateUserDeviceCommand, BaseResponse<bool>>
{
	private readonly IUserDeviceRepository _userDeviceRepository;
	private readonly IMapper _mapper;
	public UpdateUserDeviceHandler(IUserDeviceRepository userDeviceRepository, IMapper mapper)
	{
		_userDeviceRepository = userDeviceRepository;
		_mapper = mapper;
	}
	public async Task<BaseResponse<bool>> Handle(UpdateUserDeviceCommand request, CancellationToken cancellationToken)
	{
		var response = new BaseResponse<bool>();
		try
		{
			var userDevice = await _userDeviceRepository.UserDeviceById(request.Id);
			if(userDevice is null)
			{
				response.IsSuccess = false;
				response.Message = "No se puede editar un dispositivo que no existe!";
				return response;
			}
			_mapper.Map(request, userDevice);
			
			response.Data = await _userDeviceRepository.UserDeviceUpdate(userDevice);
			if(response.Data)
			{
				response.IsSuccess = true;
				response.Message = "Dispositivo Actualizado Correctamente";
			}
		}
		catch (Exception ex)
		{
			response.Message = ex.Message;			
		}
		return response;
	}
}
