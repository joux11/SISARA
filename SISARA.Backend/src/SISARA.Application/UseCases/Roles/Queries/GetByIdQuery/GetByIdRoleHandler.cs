using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.Interfaces;
using SISARA.Domain.Entities;

namespace SISARA.Application.UseCases.Roles.Queries.GetByIdQuery
{
    public class GetByIdRoleHandler : IRequestHandler<GetByIdRoleQuery, BaseResponse<Role>>
    {
        private readonly IRoleRepository _roleRepository;
        public GetByIdRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<BaseResponse<Role>> Handle(GetByIdRoleQuery request, CancellationToken cancellationToken)
        {
           var response = new BaseResponse<Role>();
            try
            {
                var role = await _roleRepository.RoleById(request.Id);
                if(role is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se encontraron registros";
                    return response;                   
                }
                response.IsSuccess = true;
                response.Data = role;
                response.Message = "Consulta Exitosa!";

            }
            catch(Exception ex) 
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
