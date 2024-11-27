using CarRentalAPI.Modals;

namespace CarRentalAPI.Services
{
    public interface ICarRentalService
    {
        Task<bool> RentCar(int carId, string email, int days);
        Task<bool> CheckCarAvailability(int carId);
        Task<IEnumerable<Car>> GetAvailableCars();
        Task AddCar(Car car);
        Task UpdateCar(int id, Car car);
        Task DeleteCar(int id);
    }
}
