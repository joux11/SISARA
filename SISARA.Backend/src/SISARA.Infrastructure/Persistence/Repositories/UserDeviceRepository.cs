using Microsoft.EntityFrameworkCore;
using SISARA.Application.Interfaces;
using SISARA.Domain.Entities;

namespace SISARA.Infrastructure.Persistence.Repositories
{
    public class UserDeviceRepository : IUserDeviceRepository
    {
        private readonly ApplicationDbContext _context;
        public UserDeviceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserDevice>> ListUserDevices()
        {
            var userDevices = await _context.UserDevice.ToListAsync();
            return userDevices;
        }

        public async Task<UserDevice> UserDeviceById(uint UserDeviceId)
        {
            var userDevice = await _context.UserDevice.FindAsync(UserDeviceId);
            return userDevice;
        }

        public async Task<bool> UserDeviceDelete(UserDevice userDevice)
        {
            _context.UserDevice.Remove(userDevice);
            var deviceDelete = await _context.SaveChangesAsync();
            return deviceDelete > 0;
        }

        public async Task<uint> UserDeviceRegister(UserDevice userDevice)
        {
            _context.UserDevice.Add(userDevice);
            await _context.SaveChangesAsync();
            return userDevice.Id;
        }

        public async Task<bool> UserDeviceUpdate(UserDevice userDevice)
        {
            _context.UserDevice.Update(userDevice);
            var updateDevice = await _context.SaveChangesAsync();
            return updateDevice > 0;
        }
    }
}
