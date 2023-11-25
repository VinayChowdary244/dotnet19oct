using BusModelLibrary;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Models.DTOs;
using BusTicketingWebApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketingWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<BookingController> _logger;


        public BookingController(IBookingService bookingService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

       // [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(BookingDTO bookingDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookingService.Add(bookingDTO);
                _logger.LogInformation("Booking created");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }

       // [Authorize]
        [HttpGet]
        public ActionResult GetAllBookings()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookingService.GetBookings();
                _logger.LogInformation("Bookings listed");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("Error Occured,Bookings not listed");
            }
            return BadRequest(errorMessage);
        }

       // [Authorize(Roles = "Admin")]
        [Route("Cancel/DeleteBooking")]
        [HttpDelete]
        public ActionResult DeleteBooking(BookingDTO bookingDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookingService.RemoveBooking(bookingDTO);
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
