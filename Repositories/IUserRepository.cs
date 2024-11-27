using CarRentalAPI.Modals;

namespace CarRentalAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(int id);
    }
}
