using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.Interfaces;
using SISARA.Domain.Entities;

namespace SISARA.Application.UseCases.Roles.Queries.GetAllQuery
{
    public class GetAllRoleHandler : IRequestHandler<GetAllRoleQuery, BaseResponse<List<Role>>>
    {
        private readonly IRoleRepository _roleRepository;
        public GetAllRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse<List<Role>>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<Role>>();
            try
            {
                var roles = await _roleRepository.ListRoles();
                if(roles is not null)
                {
                    response.IsSuccess = true;
                    response.Data = roles;
                    response.Message = "Consulta Exitosa";
                }
            }catch(Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
