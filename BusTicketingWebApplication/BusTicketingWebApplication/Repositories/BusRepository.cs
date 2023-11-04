using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;

namespace BusTicketingWebApplication.Repositories
{
    public class BusRepository : IRepository<int, Bus>
    {
        static Dictionary<int, Bus> buses = new Dictionary<int, Bus>() {
        {1,
            new Bus{
                Id=1,
                Type="Sleeper",
                Cost=100,
                Capacity=25,
                Start="Eluru",
                End="Kakinada"
                }
         },
        {2,
               new Bus{
                Id=2,
                Type="Ac",
                Cost=200,
                Capacity=80,
                Start="Rjy",
                End="Goa"
                }
        } 
    };
        public Bus Add(Bus bus)
        {
            throw new NotImplementedException();
        }

        public Bus Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Bus Get(int key)
        {
            throw new NotImplementedException();
        }

        public IList<Bus> GetAll()
        {
            throw new NotImplementedException();
        }

        public Bus Update(Bus item)
        {
            throw new NotImplementedException();
        }
    }
}
