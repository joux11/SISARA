using AutoMapper;
using SISARA.Application.DTOs.Request;
using SISARA.Domain.Entities;

namespace SISARA.Application.Mappings;

public class UserDeviceMappingProfile : Profile
{
	public UserDeviceMappingProfile()
	{
		CreateMap<RegisterUserDeviceRequestDto, UserDevice>().ReverseMap();
		CreateMap<UpdateUserDeviceRequestDto, UserDevice>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
	}

}
