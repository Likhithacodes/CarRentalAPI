using CarRentalAPI.Modals;

namespace CarRentalAPI.Repositories
{
    public interface ICarRepository
    {
        Task AddCar(Car car);
        Task<Car> GetCarById(int id);
        Task UpdateCar(int id,Car car);
        Task<IEnumerable<Car>> GetAvailableCars();
        Task UpdateCarAvailability(int id, bool isAvailable);
        Task DeleteCar(int id);
    }
}
