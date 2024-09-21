using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.Interfaces;
using SISARA.Domain.Entities;

namespace SISARA.Application.UseCases.Roles.Commands.CreateCommand
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, BaseResponse<bool>>
    {
        private readonly IRoleRepository _roleRepository;
        public CreateRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<BaseResponse<bool>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var role = new Role
                {
                    Name = request.Name!
                };
                response.Data = await _roleRepository.RoleRegister(role);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se registro el Rol correctamente";
                }
            }catch(Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
