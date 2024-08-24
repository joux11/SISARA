using SISARA.Domain.Entities;

namespace SISARA.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListUsers();
        Task<User> UserById(uint UserId);
        Task<uint> UserRegister(User user);
        Task<bool> UserUpdate(User user);
        Task<bool> UserDelete(User User);
        Task<User> UserByIdentification(string Identification);
        Task<User> UserByEmail(string Email);
        
    }
}
