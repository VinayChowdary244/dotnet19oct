using ShoppingModelLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoppingDALLibrary
{
    public interface IRepository
    {
        public Product Add(Product product);
        public Product Update(Product product);
        public Product Delete(int id);
        public Product GetById(int id);
        public List<Product> GetAll();
    }
}