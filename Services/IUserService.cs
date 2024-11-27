using CarRentalAPI.Modals;

namespace CarRentalAPI.Services
{
    public interface IUserService
    {
        Task<User> RegisterUser(User user);
        Task<string> AuthenticateUser(string email, string password);
    }
}
