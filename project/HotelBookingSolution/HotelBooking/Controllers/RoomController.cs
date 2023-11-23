using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Exceptions;
using HotelBooking.Interfaces;
using HotelBooking.Models;
using HotelBooking.Services;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            string msg = "";
            try
            {
                var res = _roomService.GetRooms();
                if (res != null)
                {
                    return Ok(res);
                }
            }
            //catching the exception thrown 
            catch (NoRoomsAvailableException e)
            {
                msg = e.Message;
            }
            return BadRequest(msg);
        }

        [HttpPost]
        //Providing Authorisation to the Admin only 
        [Authorize(Roles = "Admin")]
        [Route("Add")]
        public ActionResult Add(Room room)
        {
            string msg = "";
            try
            {
                var res = _roomService.Add(room);
                if (res != null)
                {
                    return Ok(res);
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return BadRequest(msg);
        }
    }
}
