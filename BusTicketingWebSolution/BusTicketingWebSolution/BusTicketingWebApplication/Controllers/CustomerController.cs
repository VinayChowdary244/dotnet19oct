using BusModelLibrary;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusTicketingWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBookingService _bookingService;
        private readonly ILogger<CustomerController> _logger;


        public CustomerController(IUserService userService, IBookingService bookingService, ILogger<CustomerController> logger)
        {
            _userService = userService;
            _bookingService = bookingService;
            _logger = logger;
        }
        [HttpPost]
        public ActionResult Register(UserDTO viewModel)
        {
            string message = "";
            try
            {
                var user = _userService.Register(viewModel);
                if (user != null)
                {
                    _logger.LogInformation("Register done.");

                    return Ok(user);
                }
            }
            catch (DbUpdateException exp)
            {
                message = "Duplicate username";
            }
            catch (Exception)
            {

            }


            return BadRequest(message);
        }

        [HttpPost]
        [Route("Login")]//attribute based routing
        public ActionResult Login(UserDTO userDTO)
        {
            var result = _userService.Login(userDTO);
            if (result != null)
            {
                _logger.LogInformation("Logged in successfully");
                return Ok(result);
            }
            return Unauthorized("Invalid username or password");
        }

        [HttpPost]
        [Route("BusSearch")]
        public ActionResult BusSearch(BusSearchDTO busSearchDTO) 
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _userService.BusSearch( busSearchDTO);
                _logger.LogInformation("Busses listed");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("Busses not listed");

            }
            return BadRequest(errorMessage);

        }

        [HttpPost]
        [Route("UserBookingHistory")]
        public ActionResult BookingHistory(UserNameDTO userNameDTO )
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _userService.GetBookingHistory(userNameDTO);
                _logger.LogInformation("Booking history listed");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogInformation("Booking history not listed.");

            }
            return BadRequest(errorMessage);

        }

        [HttpPut]
        [Route("UserProfile")]
        public ActionResult UserProfile(UserUpdateDTO userUpdateDTO)
        {
            string msg = "";
            try
            {
                var res = _userService.UpdateUser(userUpdateDTO);
                _logger.LogInformation("Profile updated");

                return Ok(res);
            }
            catch (Exception e)
            {
                msg = e.Message;
                _logger.LogError("Profile not updated");

            }
            return BadRequest(msg);
        }



        // [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult GetAllUsers()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _userService.GetAllUsers();
                _logger.LogInformation("All Users listed");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError(" Users not listed");


            }
            return BadRequest(errorMessage);

        }

        
        [HttpPost]
        [Route("BookTickets")]
        public ActionResult BookTickets(BusDTO busDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _userService.BookSeat(busDTO);
                _logger.LogInformation("Booking done");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("Booking not done");

            }
            return BadRequest(errorMessage);

        }
    }
}
