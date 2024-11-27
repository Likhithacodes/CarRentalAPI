using CarRentalAPI.Modals;
using CarRentalAPI.Repositories;
using CarRentalAPI.Services;


namespace CarRentalAPI.Services
{
    public class CarRentalService:ICarRentalService
    {
        private readonly ICarRepository _carRepository;
        private readonly EmailService _emailService;
        private readonly IUserRepository _userRepository;
        public CarRentalService(ICarRepository carRepository, EmailService emailService,IUserRepository userRepository)
        {
            _carRepository = carRepository;
            _emailService = emailService;
            _userRepository = userRepository;
        }
        public async Task<bool> RentCar(int carId, string email, int days)
        {
            var car = await _carRepository.GetCarById(carId);
            
           

            if (car == null || !car.IsAvailable)
                throw new Exception("Car is not available for rental.");

            car.IsAvailable = false;
            await _carRepository.UpdateCarAvailability(carId, false);

            // Calculate total price
            var totalPrice = car.PricePerDay * days;
            
            // Notify user
            await _emailService.SendEmail(email, "Booking Confirmation",
                $"Your booking for {car.Make} {car.Model} is confirmed. Total cost: ${totalPrice} for {days} days.");

            return true;
        }

        public async Task<bool> CheckCarAvailability(int carId)
        {
            var car = await _carRepository.GetCarById(carId);
            return car != null && car.IsAvailable;
        }
        public async Task<IEnumerable<Car>> GetAvailableCars()
        {
            var cars = await _carRepository.GetAvailableCars();
            return cars;
        }
        public async Task AddCar(Car car)
        {
            await _carRepository.AddCar(car);
            
        }
       public async Task UpdateCar(int id,Car car)
        {
            await _carRepository.UpdateCar(id, car);
        }
        public async Task DeleteCar(int id)
        {
            await _carRepository.DeleteCar(id);
        }

    }
}
