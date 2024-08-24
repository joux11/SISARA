using Microsoft.EntityFrameworkCore;
using SISARA.Application.Interfaces;
using SISARA.Domain.Entities;

namespace SISARA.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Role>> ListRoles()
        {
            var query = "Select * from Roles";
            var roles = await _context.Roles.FromSqlRaw(query).ToListAsync();

            return roles;
        }

        public async Task<Role> RoleById(uint RoleId)
        {
            var role = await _context.Roles.FindAsync(RoleId);
            return role;
        }

        public async Task<bool> RoleDelete(Role role)
        {
            _context.Roles.Remove(role);
            var deleteRole = await _context.SaveChangesAsync();
            return deleteRole > 0;
        }

        public async Task<bool> RoleRegister(Role role)
        {
            _context.Roles.Add(role);
            var registerRole = await _context.SaveChangesAsync();
            return registerRole > 0;
        }

        public async Task<bool> RoleUpdate(Role role)
        {
            _context.Roles.Update(role);
            var updateRole = await _context.SaveChangesAsync();
            return updateRole > 0;
        }
    }
}
