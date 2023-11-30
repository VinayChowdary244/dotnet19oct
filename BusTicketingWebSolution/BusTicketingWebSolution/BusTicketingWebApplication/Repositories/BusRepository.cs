using BusModelLibrary;
using BusTicketingWebApplication.Contexts;
using BusTicketingWebApplication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusTicketingWebApplication.Repositories
{
    public class BusRepository : IBusRepository
    {
        private readonly TicketingContext _context;
        public BusRepository(TicketingContext context)
        {
            _context = context;
        }

        public Bus Add(Bus item)
        {
            _context.Busses.Add(item);
            _context.SaveChanges();
            return item;
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
            var cus=_context.Busses.SingleOrDefault(x => x.Id == key);
            return cus;
        }

        public IList<Bus> GetAll()
        {
            if (_context.Busses.Count()==0)
            {
                return null;
            }
            return _context.Busses.ToList();

        }

        public Bus Update(Bus entity)
        {
            var cus = GetById(entity.Id);
            if (cus != null)
            {
                _context.Entry<Bus>(cus).State = EntityState.Modified;
                _context.SaveChanges();
                return cus;
            }
            return null;
        }
    }
    }

