using SISARA.Domain.Entities;

namespace SISARA.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> ListRoles();
        Task<Role> RoleById(uint RoleId);
        Task<bool> RoleRegister(Role role);
        Task<bool> RoleUpdate(Role role);
        Task<bool> RoleDelete(Role role);

    }
}
