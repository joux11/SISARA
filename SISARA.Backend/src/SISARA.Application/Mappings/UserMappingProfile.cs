using AutoMapper;
using SISARA.Application.DTOs.Request;
using SISARA.Application.DTOs.Response;
using SISARA.Domain.Entities;
using SISARA.Domain.ValueObjects;

namespace SISARA.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterUserRequestDto, User>().ReverseMap();
            CreateMap<UpdateUserRequestDto, User>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
                
            CreateMap<User, GetUserResponseDto>().ReverseMap();
            CreateMap<User, GetAllUserResponseDto>()
                //.ForMember(x => x.IsActive, x => x.MapFrom(u => u.IsActive == true ? "Activo" : "Inactivo"))
                .ReverseMap();
        }

        
    }
}
