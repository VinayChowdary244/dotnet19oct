using Microsoft.EntityFrameworkCore;
using ShoppingApp1.Interfaces;
using ShoppingApp1.Contexts;
using ShoppingApp1.Models;

namespace ShoppingApp1.Repositories
{
    public class CartRepository : IRepository<int, Cart>
    {
        private readonly ShoppingContext _context;
        public CartRepository(ShoppingContext context)
        {
            _context = context;
        }
        public Cart Add(Cart entity)
        {
            _context.Carts.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Cart Delete(int key)
        {
            var cart = GetById(key);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                _context.SaveChanges();
                return cart;
            }
            return null;
        }

        public IList<Cart> GetAll()
        {

            if (_context.Carts.Count() == 0)
                return null;
            return _context.Carts.ToList();
        }

        public Cart GetById(int key)
        {
            var cart = _context.Carts.SingleOrDefault(u => u.cartNumber == key);
            return cart;
        }

        public Cart Update(Cart entity)
        {
            var cart = GetById(entity.cartNumber);
            if (cart != null)
            {
                _context.Entry<Cart>(cart).State = EntityState.Modified;
                _context.SaveChanges();
                return cart;
            }
            return null;
        }
    }
}
