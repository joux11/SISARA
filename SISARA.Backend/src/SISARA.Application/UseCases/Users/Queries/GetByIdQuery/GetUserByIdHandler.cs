using AutoMapper;
using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.DTOs.Response;
using SISARA.Application.Interfaces;

namespace SISARA.Application.UseCases.Users.Queries.GetByIdQuery
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, BaseResponse<GetUserResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<GetUserResponseDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var respose = new BaseResponse<GetUserResponseDto>();
            try
            {
                var user = await _userRepository.UserById(request.Id);
                if (user is null)
                {
                    respose.IsSuccess = false;
                    respose.Message = "El Usuario no existe.";
                    return respose;
                }
                respose.IsSuccess = true;
                respose.Data = _mapper.Map<GetUserResponseDto>(user);
                respose.Message = "Consulta Exitosa!";

            }
            catch(Exception ex)
            {
                respose.Message = ex.Message;
            }
            return respose;
        }
    }
}
