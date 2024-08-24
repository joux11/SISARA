using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.Interfaces;

namespace SISARA.Application.UseCases.Users.Commands.DeleteCommand
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, BaseResponse<bool>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var user = await _userRepository.UserById(request.Id);
                if(user is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se puede Eliminar un usuario no existente";
                    return response;
                }
                response.Data = await _userRepository.UserDelete(user);
                if (response.Data)
                {
                    response.Message = "Usuario Eliminado!";
                    response.IsSuccess = true;
                }

            }catch(Exception ex)
            {
                response.Message = ex.Message;
            }


            return response;
        }
    }
}
