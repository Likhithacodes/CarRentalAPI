using CarRentalAPI.Modals;
using Microsoft.EntityFrameworkCore;
namespace CarRentalAPI.Data
{
    public class CarRentalContext:DbContext
    {
        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options) { }
        public DbSet<Car> cars { get; set; }
        public DbSet<User> users { get; set; }
    }
}
