using AutoMapper;
using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.DTOs.Response;
using SISARA.Application.Interfaces;

namespace SISARA.Application.UseCases.Users.Queries.GetAllQuery
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, BaseResponse<IEnumerable<GetAllUserResponseDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<IEnumerable<GetAllUserResponseDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllUserResponseDto>>();
            try
            {
                var users = await _userRepository.ListUsers();
                if(users is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<GetAllUserResponseDto>>(users);
                    response.Message = "Consulta exitosa";
                }
            }catch(Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
