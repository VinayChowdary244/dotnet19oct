using BusTicketingWebApplication.Models;

namespace BusTicketingWebApplication.Interfaces
{
    public interface IBusService
    {
        List<Bus> GetBuses();
        Bus Add(Bus bus);
    }
}