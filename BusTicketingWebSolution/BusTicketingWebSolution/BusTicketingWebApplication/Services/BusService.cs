using BusTicketingWebApplication.Exceptions;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Exceptions;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusModelLibrary;

namespace BusTicketingWebApplication.Services
{
    public class BusService : IBusService
    {
        private readonly IRepository<int, Bus> _busRepository;

        public BusService(IRepository<int, Bus> repository)
        {
            _busRepository = repository;
        }
        public Bus Add(Bus bus)
        {
            if (bus.Capacity > 10)
            {
                var result = _busRepository.Add(bus);
                return result;
            }
            return null;
        }

        public List<Bus> GetBuses()
        {
            var buses = _busRepository.GetAll();
            if (buses != null)
            {
                return buses.ToList();
            }
            throw new NoBusesAvailableException();
        }
    }
}