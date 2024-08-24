using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.Interfaces;

namespace SISARA.Application.UseCases.Roles.Commands.UpdateCommand
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, BaseResponse<bool>>
    {
        private readonly IRoleRepository _roleRepository;
        public UpdateRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<BaseResponse<bool>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var role = await _roleRepository.RoleById(request.Id);
                if(role is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se puede actualizar Rol que no existe!";
                    return response;
                }
                role.Name = request.Name ?? role.Name;
                role.IsActive = request.IsActive ?? role.IsActive;
                response.Data = await _roleRepository.RoleUpdate(role);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Rol Actualizado con exito!";
                }

            }catch(Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
