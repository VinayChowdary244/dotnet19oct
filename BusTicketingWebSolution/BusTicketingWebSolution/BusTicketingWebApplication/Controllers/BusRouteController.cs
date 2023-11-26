using BusModelLibrary;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTicketingWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRouteController : ControllerBase
    {
        private readonly IBusRouteService _busRouteService;
        private readonly ILogger<BusRouteController> _logger;


        public BusRouteController(IBusRouteService busRouteService, ILogger<BusRouteController> logger)
        {
            _busRouteService = busRouteService;
            _logger = logger;
        }
        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busRouteService.GetRoutes();
                _logger.LogInformation("All Bus Routes listed");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("Error Occured,Bus Routes not listed");
            }
            return BadRequest(errorMessage);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(BusRoute busRoute)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busRouteService.Add(busRoute);
                _logger.LogInformation("Bus Route added");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError(" Bus Route not added");

            }
            return BadRequest(errorMessage);
        }

        
    }
}
