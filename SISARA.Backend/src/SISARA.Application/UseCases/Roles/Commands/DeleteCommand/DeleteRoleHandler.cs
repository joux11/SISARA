using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.Interfaces;

namespace SISARA.Application.UseCases.Roles.Commands.DeleteCommand
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand,BaseResponse<bool>>
    {
        private readonly IRoleRepository _roleRepository;
        public DeleteRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var role = await _roleRepository.RoleById(request.Id);
                if(role is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se puede eliminar un rol que no existe";
                    return response;
                }
                response.Data = await _roleRepository.RoleDelete(role);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Rol Eliminado!";
                }
            }catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
