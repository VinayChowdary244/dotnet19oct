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
        private readonly IBookedSeatService _bookedSeatService;
        private readonly ILogger<BookingController> _logger;


        public BookingController(IBookingService bookingService, ILogger<BookingController> logger, IBookedSeatService bookedSeatService)
        {
            _bookingService = bookingService;
            _logger = logger;
            _bookedSeatService = bookedSeatService;
        }

         [Authorize]
        [HttpPost]
        public ActionResult Create(BookingDTO bookingDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookingService.Add(bookingDTO);
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

        [HttpPost]
        [Route("BookedSeatsList")]
        public ActionResult BookedSeatsList(BusIdDTO busIdDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookedSeatService.GetSeatsById(busIdDTO);
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

        [Authorize(Roles = "Admin")]
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
        public ActionResult DeleteBooking(BookingIdDTO bookingIdDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _bookingService.RemoveBooking(bookingIdDTO);
                _logger.LogInformation("Booking deleted");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("Booking not deleted");

            }
            return BadRequest(errorMessage);
        }

    }
}
