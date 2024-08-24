using AutoMapper;
using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.Interfaces;

namespace SISARA.Application.UseCases.Users.Commands.UpdateCommand
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, BaseResponse<bool>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var user = await _userRepository.UserById(request.Id);
                if(user is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se puede actualizar un Usuario que no existe.";
                    return response;
                }

                _mapper.Map(request,user);
                
                response.IsSuccess = true;
                response.Data = await _userRepository.UserUpdate(user);
                response.Message = "Usuario Actualizado";

            }catch(Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
