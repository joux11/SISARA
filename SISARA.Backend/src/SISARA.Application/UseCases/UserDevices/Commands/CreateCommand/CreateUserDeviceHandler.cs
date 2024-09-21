using AutoMapper;
using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.Interfaces;
using SISARA.Domain.Entities;

namespace SISARA.Application.UseCases.UserDevices.Commands.CreateCommand;

public class CreateUserDeviceHandler : IRequestHandler<CreateUserDeviceCommand, BaseResponse<bool>>
{
	private readonly IUserDeviceRepository _userDeviceRepository;
	private readonly IMapper _mapper;
	public CreateUserDeviceHandler(IUserDeviceRepository userDeviceRepository, IMapper mapper)
	{
		_userDeviceRepository = userDeviceRepository;
		_mapper = mapper;
	}
	public async Task<BaseResponse<bool>> Handle(CreateUserDeviceCommand request, CancellationToken cancellationToken)
	{
		var response = new BaseResponse<bool>();
		try
		{
			var userDevice = _mapper.Map<UserDevice>(request);
			var data = await _userDeviceRepository.UserDeviceRegister(userDevice);
			if(data > 0){
				response.IsSuccess = true;
				response.Message = "Dispositivo Registrado Correctamente!";
			}
			
		}catch(Exception ex)
		{
			response.Message = ex.Message;
		}
		return response;
	}
}
