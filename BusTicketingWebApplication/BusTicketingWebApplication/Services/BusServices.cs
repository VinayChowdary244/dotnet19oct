using BusTicketingWebApplication.Interfaces;

namespace BusTicketingWebApplication.Services
{
    public class BusServices : IBusService
    {
        IRepository<int, Bus> repository;

    }
}
