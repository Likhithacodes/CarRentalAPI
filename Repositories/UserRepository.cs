using CarRentalAPI.Data;
using CarRentalAPI.Modals;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly CarRentalContext context;
        public UserRepository(CarRentalContext context)
        {
            this.context = context;
        }
        public async Task<User> AddUser(User user)
        {
            context.users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
        public async Task<User> GetUserByEmail(string email) =>
            await context.users.FirstOrDefaultAsync(u=>u.Email== email);


        public async Task<User> GetUserById(int id) => await context.users.FindAsync(id);
    }
}
