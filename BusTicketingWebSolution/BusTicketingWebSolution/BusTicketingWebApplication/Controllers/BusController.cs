﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTicketingWebApplication.Exceptions;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusModelLibrary;
using BusTicketingWebApplication.Models.DTOs;
using BusTicketingWebApplication.Services;
using Microsoft.AspNetCore.Cors;

namespace BusTicketingWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;
        private readonly ILogger<BusController> _logger;



        public BusController(IBusService busService, ILogger<BusController> logger)
        {
            _busService = busService;
            _logger = logger;
        }
      [Authorize]
      [HttpGet]
        public ActionResult GetAllBusses()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busService.GetBuses();
                _logger.LogInformation("Busses listed");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("Error Occured,Product not listed");
            }
            return BadRequest(errorMessage);
        }
     // [Authorize(Roles = "Admin")]
      [HttpPost]
        public ActionResult Create(Bus bus)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busService.Add(bus);
                _logger.LogInformation("Bus added");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("Bus not added");

            }
            return BadRequest(errorMessage);
        }


       // [Authorize(Roles = "Admin")]
        [Route("DeleteBus")]
        [HttpDelete]
        public ActionResult DeleteBus(BusIdDTO busIdDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busService.RemoveBus(busIdDTO);
                _logger.LogInformation("Bus deleted");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("Bus not deleted");

            }
            return BadRequest(errorMessage);
        }

        

        //  [Authorize(Roles = "Admin")]
        [Route("UpdateBus")]
        [HttpPut]
        public ActionResult UpdateBus(BusDTO busDTO)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _busService.UpdateBus( busDTO);
                _logger.LogInformation("Bus updated");

                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError("Bus not updated");

            }
            return BadRequest(errorMessage);
        }


    }

}