using Microsoft.EntityFrameworkCore;
using SISARA.Application.Interfaces;
using SISARA.Domain.Entities;

namespace SISARA.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> ListUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> UserByEmail(string Email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);
            return user;
        }

        public async Task<User> UserById(uint UserId)
        {
            var user = await _context.Users.FindAsync(UserId);
            return user;
        }

        public async Task<User> UserByIdentification(string Identification)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Identification == Identification);
            return user;
        }

        public async Task<bool> UserDelete(User user)
        {
            _context.Users.Remove(user);
            var userDelete = await _context.SaveChangesAsync();
            return userDelete > 0;
;        }

        public async Task<uint> UserRegister(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> UserUpdate(User user)
        {
            _context.Users.Update(user);
            var userUpdate = await _context.SaveChangesAsync();
            return userUpdate > 0;
        }
    }
}
