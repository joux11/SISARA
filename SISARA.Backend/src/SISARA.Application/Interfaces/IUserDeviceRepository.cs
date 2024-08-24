using SISARA.Domain.Entities;

namespace SISARA.Application.Interfaces
{
    public interface IUserDeviceRepository
    {
        Task<IEnumerable<UserDevice>> ListUserDevices();
        Task<UserDevice> UserDeviceById(uint UserDeviceId);
        Task<uint> UserDeviceRegister(UserDevice userDevice);
        Task<bool> UserDeviceUpdate(UserDevice userDevice);
        Task<bool> UserDeviceDelete(UserDevice userDevice);
    }
}
