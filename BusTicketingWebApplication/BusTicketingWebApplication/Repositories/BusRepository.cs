using BusTicketingWebApplication.Contexts;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTicketingWebApplication.Repositories
{
    public class BusRepository : IRepository<int, Bus>
    {
        private readonly TicketingContext _context;
        public BusRepository(TicketingContext context)
        {
            _context = context;
        }
        public Bus Add(Bus entity)
        {
            _context.Busses.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Bus Delete(int key)
        {
            var bus = GetById(key);
            if (bus != null)
            {
                _context.Busses.Remove(bus);
                _context.SaveChanges();
                return bus;
            }
            return null;
        }
        public Bus GetById(int key)
        {
            var bus = _context.Busses.SingleOrDefault(u => u.Id == key);
            return bus;
        }

      

        public IList<Bus> GetAll()
        {
            if (_context.Busses.Count() == 0)
                return null;
            return _context.Busses.ToList();
        }

        public Bus Update(Bus entity)
        {
            var bus = GetById(entity.Id);
            if (bus != null)
            {
                _context.Entry<Bus>(bus).State = EntityState.Modified;
                _context.SaveChanges();
                return bus;
            }
            return null;
        }
    }
}
