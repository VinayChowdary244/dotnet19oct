using HotelBooking.Exceptions;
using HotelBooking.Interfaces;
using HotelBooking.Models;
using HotelBooking.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBookingService _bookingService;

        public CustomerController(IUserService userService, IBookingService bookingService)
        {
            _userService = userService;
            _bookingService = bookingService;
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
                return Ok(result);
            }
            return Unauthorized("Invalid username or password");
        }

        [HttpPost]
        [Route("HotelSearch")]
        public ActionResult HotelSearch(HotelDTO hotelDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _userService.HotelSearch(hotelDTO);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);

        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult GetAllUsers()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _userService.GetAllUsers();
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);

        }
        [HttpGet]
        [Route("ViewBooking")]
        public ActionResult GetBookings()
        {
            string errorMessage = string.Empty;
            try
            {

                var result = _bookingService.GetBookings();
                return Ok(result);
            }
            catch (NoRoomsAvailableException e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }

        [HttpPost]
        [Route("RoomBooking")]
        public ActionResult Create(Booking booking)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookingService.Add(booking);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
    }

}
