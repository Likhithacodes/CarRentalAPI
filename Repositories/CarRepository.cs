using CarRentalAPI.Data;
using CarRentalAPI.Modals;
using Microsoft.EntityFrameworkCore;
namespace CarRentalAPI.Repositories
{
    public class CarRepository:ICarRepository
    {
        private readonly CarRentalContext _context;

        public CarRepository(CarRentalContext context)
        {
            _context = context;
        }
        public async Task AddCar(Car car)
        {
             _context.cars.Add(car);
            await _context.SaveChangesAsync();

        }
        public async Task<Car> GetCarById(int id)
        {
            return await _context.cars.FindAsync(id);
        }
        public async Task<User> GetUserById(int id)
        {
            return await _context.users.FindAsync(id);
        }
        public async Task<IEnumerable<Car>> GetAvailableCars()
        {
            return await _context.cars.Where(c => c.IsAvailable).ToListAsync();
        }
        public async Task UpdateCarAvailability(int id, bool isAvailable)
        {
            var car = await GetCarById(id);
            if (car != null)
            {
                car.IsAvailable = isAvailable;
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateCar(int id, Car car)
        {
            var existingCar = await _context.cars.FindAsync(id);

            if (existingCar == null)
            {
                // Handle the case where the car does not exist
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            }

            // Update the properties of the existing car
            existingCar.Make = car.Make;
            existingCar.Model = car.Model;
            existingCar.Year = car.Year;
            existingCar.IsAvailable = car.IsAvailable;
            existingCar.PricePerDay = car.PricePerDay;

            // Save changes to the database
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCar(int id)
        {
            var existingCar = await _context.cars.FindAsync(id);
            if (existingCar == null)
            {
                // Handle the case where the car does not exist
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            }
             _context.cars.Remove(existingCar);
            await _context.SaveChangesAsync();
        }
    }
}
