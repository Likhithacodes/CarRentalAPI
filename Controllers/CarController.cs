using CarRentalAPI.Modals;
using CarRentalAPI.Repositories;
using CarRentalAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRentalService _carRentalService;
        private readonly ICarRepository _carRepository;
        private readonly IUserRepository _UserRepository;
        private readonly EmailService _emailService;
        public CarController(ICarRentalService carRentalService,ICarRepository carRepository,EmailService emailservice,IUserRepository userRepository)
        {
            _carRentalService = carRentalService;
            _carRepository = carRepository;
            _emailService = emailservice;
            _UserRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAvailableCars()
        {
            var cars = await _carRentalService.GetAvailableCars();
            return Ok(cars);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _carRentalService.AddCar(car);
            return CreatedAtAction(nameof(GetAvailableCars), new { id = car.Id }, car);
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car car)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _carRentalService.UpdateCar(id, car);
            

            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carRentalService.DeleteCar(id);
            return NoContent();
        }
        [HttpPost("rent")]
        [Authorize]
        public async Task<IActionResult> RentCar(int carId, string email, int days)
        {
            try
            {
                var result = await _carRentalService.RentCar(carId, email, days);
                if (result)
                {
                    
                    var car = await _carRepository.GetCarById(carId);      

                   
                    var subject = "Car Rental Confirmation";
                    var message = $"Dear {email},\n\nYour rental of the car {car.Make} {car.Model} for {days} days has been confirmed.\n\nThank you for using our service!";

                    // Send the email
                    await _emailService.SendEmail(email, subject, message);
                }
                return Ok(new { Success = result, Message = "Car rented successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }


    }
}
